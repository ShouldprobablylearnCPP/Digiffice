using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote.AllnoteTabClasses
{
    public class DigifficeAllnoteHomeTab
    {

        // Class Variables
        public ComboBox fontFamilyComboBox = new ComboBox();
        public ComboBox fontSizeComboBox = new ComboBox();
        public List<string> fontList = new List<string>();
        public List<string> fontSizeList = new List<string>();

        public void InitialiseUI(Panel rbnPnl, EventHandler fontFamilyComboBox_SelectionChangeCommited, EventHandler fontSizeComboBox_SelectionChangeCommitted)
        {
            // Check Prerequisites

            // Fill Lists
            UpdateFontList(new List<string> { "Roboto" });
            UpdateFontSizeList(new List<string> { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" });

            // Todo: Make Controls look aero-style

            // fontFamilyComboBox
            fontFamilyComboBox.Name = "FontFamilyComboBox";
            fontFamilyComboBox.Enabled = true;

            fontFamilyComboBox.Size = new Size(150, 30);
            fontFamilyComboBox.Location = new Point(20, 20);
            fontFamilyComboBox.BackColor = SystemColors.Control;
            fontFamilyComboBox.ForeColor = SystemColors.ControlText;
            fontFamilyComboBox.Text = fontList[0];
            fontFamilyComboBox.Font = new Font("Roboto", 8, FontStyle.Regular);
            fontFamilyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            fontFamilyComboBox.FlatStyle = FlatStyle.Standard;

            fontFamilyComboBox.SelectionChangeCommitted += fontFamilyComboBox_SelectionChangeCommited;

            rbnPnl.Controls.Add(fontFamilyComboBox);

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

            fontSizeComboBox.SelectionChangeCommitted += fontSizeComboBox_SelectionChangeCommitted;

            rbnPnl.Controls.Add(fontSizeComboBox);
        }

        public void UpdateFontList(List<string> newFontList)
        {
            fontList = newFontList;
            fontFamilyComboBox.Items.Clear();
            fontFamilyComboBox.Items.AddRange(fontList.ToArray());
            fontFamilyComboBox.Text = fontList.FirstOrDefault();
        }

        public void UpdateFontSizeList(List<string> newFontSizeList)
        {
            fontSizeList = newFontSizeList;
            fontSizeComboBox.Items.Clear();
            fontSizeComboBox.Items.AddRange(fontSizeList.ToArray());
            fontSizeComboBox.Text = fontSizeList.FirstOrDefault();
        }

        public List<Control> retrieveTextFormattingControls()
        {
            List<Control> controls = new List<Control>();
            controls.Add(fontFamilyComboBox);
            controls.Add(fontSizeComboBox);
            return controls;
        }
    }
}
