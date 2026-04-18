using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using DigifficeWPFControls;
using Control = System.Windows.Forms.Control;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using SystemColors = System.Drawing.SystemColors;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficePeerspace
{
    public class PeerspaceManager
    {
        // Class Variables (P2P)

        // Class Variables (General)
        int PeerspaceType = 0; // 0 = None (Will cause error) | 1 = P2P | 2 = Client-Server (Not yet implemented)
        WPFDataGrid globalDataGrid;
        string txtFileDescription = "Plain Text Document";
        string dgpdFileDescription = "Digiffice Peerspace Data File";
        string dgpuFileDescription = "Digiffice Peerspace Userlist File";
        string mp3FileDescription = "MP3 Audio File";
        string unkownFileDescription = "Unknown File Type";
        string directoryDescription = "Folder";

        public string GetPeerspaceType(string peerspaceDirPath)
        {
            // Find data file in directory
            string dataFilePath = @$"{peerspaceDirPath}/PEERSPACE_DATA.dgpd";
            using (FileStream fs = File.OpenRead(dataFilePath))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    // Find |PEERSPACE_TYPE: ... in data file and get the value after the colon
                    string dataLine = File.ReadLines(dataFilePath).FirstOrDefault(line => line.StartsWith("|PEERSPACE_TYPE:"));
                    if (dataLine == null)
                    {
                        throw new InvalidDataException("PEERSPACE_TYPE not found in data file in peerspace directory: " + peerspaceDirPath);
                    }
                    else
                    {
                        return dataLine["|PEERSPACE_TYPE:".Length..].Trim();
                    }
                }
            }
        }

        public void MapPeerspace(string peerspaceDirectory, Control parentControl)
        {
            string peerspaceType = GetPeerspaceType(peerspaceDirectory);
            PeerspaceType = peerspaceType switch
            {
                "P2P" => 1,
                "Client-Server" => 2,
                _ => throw new InvalidDataException("Invalid peerspace type in data file in peerspace directory: " + peerspaceDirectory)
            };

            if (peerspaceType == "P2P")
            {
                MapP2PPeerspace(peerspaceDirectory, parentControl);
            }
        }

        public void MapP2PPeerspace(string peerspaceDirectory, Control parentControl)
        {
            // Get List of Files and Directories in the peerspace directory
            string[] files = Directory.GetFiles(peerspaceDirectory);
            string[] directories = Directory.GetDirectories(peerspaceDirectory);

            // Map data onto a grid control (WPF Grid using ElementHost)
            // Todo: Finish this method to actually read the data and map it onto the grid control
            ElementHost elementHost = new ElementHost();

            // Set properties of the ElementHost
            elementHost.Location = new Point(1, 41);
            elementHost.Size = new Size(parentControl.Width - 2, parentControl.Height - 42);

            WPFDataGrid dataGrid = new WPFDataGrid();

            // Remove user permissions from row functionality of the grid control (we don't want users to be able to add or delete rows, just view the data)
            dataGrid.dataGridControl.CanUserAddRows = false;
            dataGrid.dataGridControl.CanUserDeleteRows = false;
            dataGrid.dataGridControl.CanUserResizeColumns = false;
            dataGrid.dataGridControl.CanUserResizeRows = false;
            dataGrid.dataGridControl.CanUserReorderColumns = false;
            dataGrid.dataGridControl.CanUserSortColumns = false;
            dataGrid.dataGridControl.IsReadOnly = true;
            dataGrid.dataGridControl.HeadersVisibility = DataGridHeadersVisibility.None;

            // Autogenerate Collums
            dataGrid.dataGridControl.AutoGenerateColumns = false;

            // Set properties of the grid control
            dataGrid.dataGridControl.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(SystemColors.Control.A, SystemColors.Control.R, SystemColors.Control.G, SystemColors.Control.B));
            dataGrid.dataGridControl.RowBackground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(SystemColors.Control.A, SystemColors.Control.R, SystemColors.Control.G, SystemColors.Control.B));
            dataGrid.dataGridControl.ColumnWidth = DataGridLength.Auto;
            dataGrid.dataGridControl.RowHeight = 30;
            dataGrid.dataGridControl.GridLinesVisibility = DataGridGridLinesVisibility.None;

            // Add the files and directories to the grid control as rows with two columns: Name and Type (File or Directory)
            foreach (var item in files)
            {
                // Instantiate new row
                DataGridRow newRow = new DataGridRow();

                // Check for type of file and set icon. Any unrecognised file types will get a default file icon
                string fileType = Path.GetExtension(item).ToString().ToLower();
                switch (fileType)
                {
                    case ".txt":
                        newRow.Item = new { Type = Properties.Resources._30x30_TextFileIcon_WPFCompat, Name = Path.GetFileName(item), FileDesc = txtFileDescription };
                        break;

                    case ".dgpd":
                        newRow.Item = new { Type = Properties.Resources._30x30_DigifficePeerspaceDataFileIcon_WPFCompat, Name = Path.GetFileName(item), FileDesc = dgpdFileDescription };
                        break;

                    case ".dgpu":
                        newRow.Item = new { Type = Properties.Resources._30x30_DigifficePeerspaceUserlistFileIcon_WPFCompat, Name = Path.GetFileName(item), FileDesc = dgpuFileDescription };
                        break;

                    case ".mp3":
                        newRow.Item = new { Type = Properties.Resources._30x30_MP3FileIcon_WPFCompat, Name = Path.GetFileName(item), FileDesc = mp3FileDescription };
                        break;

                    default:
                        newRow.Item = new { Type = "File", Name = Path.GetFileName(item), FileDesc = unkownFileDescription };
                        break;
                }

                // Set alignment of the row to center for both horizontal and vertical alignment
                newRow.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                newRow.VerticalContentAlignment = VerticalAlignment.Center;

                // Add the row to the grid control
                dataGrid.dataGridControl.Items.Add(newRow);

                // Set datagrid to global grid for future use
                globalDataGrid = dataGrid;
            }

            foreach (var item in directories)
            {
                // Instantiate new row
                DataGridRow newRow = new DataGridRow();
                newRow.Item = new { Type = Properties.Resources._30x30_DirClosedIcon_WPFCompat, Name = Path.GetFileName(item), Open = false, Nest = 0, ParentDir = Path.GetDirectoryName(item), FileDesc = directoryDescription };

                // Set alignment of the row to center for both horizontal and vertical alignment
                newRow.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                newRow.VerticalContentAlignment = VerticalAlignment.Center;

                // Add directory clicked event
                newRow.MouseDoubleClick += PeerspaceMap_DirectoryDoubleClicked;

                // Add the row to the grid control
                dataGrid.dataGridControl.Items.Add(newRow);
            }

            // Add Type column to the grid control
            DataGridTemplateColumn typeColumn = new DataGridTemplateColumn();
            typeColumn.Header = "Type";
            typeColumn.Width = 30;

            FrameworkElementFactory typeFactory = new FrameworkElementFactory(typeof(System.Windows.Controls.Image));

            System.Windows.Data.Binding imageBinding = new System.Windows.Data.Binding("Type");
            typeFactory.SetBinding(System.Windows.Controls.Image.SourceProperty, imageBinding);
            typeFactory.SetValue(System.Windows.Controls.Image.WidthProperty, 30.0);
            typeFactory.SetValue(System.Windows.Controls.Image.HeightProperty, 30.0);
            typeFactory.SetValue(System.Windows.Controls.Image.StretchProperty, System.Windows.Media.Stretch.UniformToFill);

            DataTemplate typeTemplate = new DataTemplate();
            typeTemplate.VisualTree = typeFactory;
            typeColumn.CellTemplate = typeTemplate;

            dataGrid.dataGridControl.Columns.Add(typeColumn);

            // Add Name column to the grid control
            dataGrid.dataGridControl.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new System.Windows.Data.Binding("Name") });

            // Add File Description column to the grid control
            dataGrid.dataGridControl.Columns.Add(new DataGridTextColumn { Header = "Description", Binding = new System.Windows.Data.Binding("FileDesc") });

            elementHost.Child = dataGrid;
            parentControl.Controls.Add(elementHost);
        }

        // Real-Time Peerspace Functions
        public void MapP2PPeerspaceSubdirectory(WPFDataGrid dataGrid, string subdirectoryPath, int nestLevel)
        {
            // Get List of Files and Directories in the subdirectory
            string[] files = Directory.GetFiles(subdirectoryPath);
            string[] directories = Directory.GetDirectories(subdirectoryPath);
    
            // Map the new data onto the grid control
            foreach (var item in files)
            {
                // Instantiate new row
                DataGridRow newRow = new DataGridRow();
    
                // Check for type of file and set icon. Any unrecognised file types will get a default file icon
                string fileType = Path.GetExtension(item).ToString().ToLower(); // Convert to lowercase to ensure case-insensitive comparison
                switch (fileType)
                {
                    case ".txt":
                        newRow.Item = new { Type = Properties.Resources._30x30_TextFileIcon_WPFCompat, Name = Path.GetFileName(item), FileDesc = txtFileDescription };
                        break;
    
                    case ".dgpd":
                        newRow.Item = new { Type = Properties.Resources._30x30_DigifficePeerspaceDataFileIcon_WPFCompat, Name = Path.GetFileName(item), FileDesc = dgpdFileDescription };
                        break;
    
                    case ".dgpu":
                        newRow.Item = new { Type = Properties.Resources._30x30_DigifficePeerspaceUserlistFileIcon_WPFCompat, Name = Path.GetFileName(item), FileDesc = dgpuFileDescription };
                        break;

                    case ".mp3":
                        newRow.Item = new { Type = Properties.Resources._30x30_MP3FileIcon_WPFCompat, Name = Path.GetFileName(item), FileDesc = mp3FileDescription };
                        break;

                    default:
                        newRow.Item = new { Type = "File", Name = Path.GetFileName(item), FileDesc = unkownFileDescription };
                        break;
                }
    
                // Set alignment of the row to center for both horizontal and vertical alignment
                newRow.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                newRow.VerticalContentAlignment = VerticalAlignment.Center;

                // Set left margin of the row based on the nest level (to create an indented effect for subdirectories)
                newRow.Margin = new Thickness(nestLevel * 30, 0, 0, 0);

                // Add the row to the grid control
                dataGrid.dataGridControl.Items.Add(newRow);
            }

            foreach (var item in directories)
            {
                // Instantiate new row
                DataGridRow newRow = new DataGridRow();
                newRow.Item = new { Type = Properties.Resources._30x30_DirClosedIcon_WPFCompat, Name = Path.GetFileName(item), Open = false, Nest = nestLevel, ParentDir = Path.GetDirectoryName(item), FileDesc = directoryDescription };

                // Set alignment of the row to center for both horizontal and vertical alignment
                newRow.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                newRow.VerticalContentAlignment = VerticalAlignment.Center;

                // Add directory clicked event
                newRow.MouseDoubleClick += PeerspaceMap_DirectoryDoubleClicked;

                // Set left margin of the row based on the nest level (to create an indented effect for subdirectories)
                newRow.Margin = new Thickness(nestLevel * 30, 0, 0, 0);

                // Add the row to the grid control
                dataGrid.dataGridControl.Items.Add(newRow);
            }
        }
         
        // Events
        public void PeerspaceMap_DirectoryDoubleClicked(object sender, EventArgs e)
        {
            DataGridRow senderRow = (DataGridRow)sender;

            if (((dynamic)senderRow.Item).Open)
            {
                senderRow.Item = new { Type = Properties.Resources._30x30_DirClosedIcon_WPFCompat, Name = ((dynamic)senderRow.Item).Name, Open = false, Nest = ((dynamic)senderRow.Item).Nest, ParentDir = ((dynamic)senderRow.Item).ParentDir, FileDesc = ((dynamic)senderRow.Item).FileDesc };
            }
            else
            {
                senderRow.Item = new { Type = Properties.Resources._30x30_DirOpenIcon_WPFCompat, Name = ((dynamic)senderRow.Item).Name, Open = true, Nest = ((dynamic)senderRow.Item).Nest, ParentDir = ((dynamic)senderRow.Item).ParentDir, FileDesc = ((dynamic)senderRow.Item).FileDesc };
                MessageBox.Show("Directory double-clicked: " + ((dynamic)senderRow.Item).Name);

                // 1 = P2P | 2 = Client-Server (Not yet implemented)
                if (PeerspaceType == 1)
                {
                    MapP2PPeerspaceSubdirectory(globalDataGrid, ((dynamic)senderRow.Item).ParentDir + "\\" + ((dynamic)senderRow.Item).Name, ((dynamic)senderRow.Item).Nest + 1);
                }
                else if (PeerspaceType == 2)
                {
                    // Not yet implemented
                }
                else
                {
                    throw new InvalidDataException("Invalid peerspace type: " + PeerspaceType);
                }
            }
        }
    }
}
