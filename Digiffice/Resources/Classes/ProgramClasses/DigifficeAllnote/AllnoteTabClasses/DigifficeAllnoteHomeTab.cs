using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses
{
    public class DigifficeAllnoteHomeTab
    {
        // Class Elements
        public ComboBox fontComboBox = new ComboBox();
        public ComboBox fontSizeComboBox = new ComboBox();

        // Class Variables
        public List<string> fontList = new List<string>();
        public List<string> fontSizeList = new List<string>();

        public void InitialiseUI(Panel rbnPnl)
        {
            // Check Prerequisites

            // Fill Lists
            UpdateFontList(new List<string> { "Placeholder" });
            UpdateFontSizeList(new List<string> { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" });

            // Todo: Make Controls look aero-style

            // fontComboBox
            fontComboBox.Name = "FontComboBox";
            fontComboBox.Enabled = true;

            fontComboBox.Size = new Size(150, 30);
            fontComboBox.Location = new Point(20, 20);
            fontComboBox.BackColor = SystemColors.Control;
            fontComboBox.ForeColor = SystemColors.ControlText;
            fontComboBox.Text = fontList[0];
            fontComboBox.Font = new Font("Roboto", 8, FontStyle.Regular);
            fontComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            fontComboBox.FlatStyle = FlatStyle.Standard;

            rbnPnl.Controls.Add(fontComboBox);

            // fontSizeComboBox
            fontSizeComboBox.Name = "FontSizeComboBox";
            fontSizeComboBox.Enabled = true;

            fontSizeComboBox.Size = new Size(60, 30);
            fontSizeComboBox.Location = new Point(170, 20);
            fontSizeComboBox.BackColor = SystemColors.Control;
            fontSizeComboBox.ForeColor = SystemColors.ControlText;
            fontSizeComboBox.Text = fontSizeList[0];
            fontSizeComboBox.Font = new Font("Roboto", 8, FontStyle.Regular);
            fontSizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            
            fontSizeComboBox.FlatStyle = FlatStyle.Standard;

            rbnPnl.Controls.Add(fontSizeComboBox);
        }

        public void UpdateFontList(List<string> newFontList)
        {
            fontList = newFontList;
            fontComboBox.Items.Clear();
            fontComboBox.Items.AddRange(fontList.ToArray());
            fontComboBox.Text = fontList.FirstOrDefault();
        }

        public void UpdateFontSizeList(List<string> newFontSizeList)
        {
            fontSizeList = newFontSizeList;
            fontSizeComboBox.Items.Clear();
            fontSizeComboBox.Items.AddRange(fontSizeList.ToArray());
            fontSizeComboBox.Text = fontSizeList.FirstOrDefault();
        }
    }
}
