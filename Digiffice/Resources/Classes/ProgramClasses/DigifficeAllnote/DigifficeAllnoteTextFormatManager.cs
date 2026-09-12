using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote
{
    public class DigifficeAllnoteTextFormatManager
    {
        // Class Variables
        public int txtSize = 10;
        public Color txtColor = Color.Black;
        public Color txtHighlightColor = Color.Transparent;
        public bool txtBullet = false;
        public HorizontalAlignment txtAlign = HorizontalAlignment.Left;

        public FontFamily fontFamily = new FontFamily("Roboto");
        public FontStyle fontWeight = FontStyle.Regular;
        public FontStyle fontItallic = FontStyle.Regular;
        public FontStyle fontUnderline = FontStyle.Regular;
        public FontStyle fontStrike = FontStyle.Regular;

        //
        //
        // Presenter
        //
        //
        public void setDefaultTextFormat()
        {
            txtSize = 10;
            txtColor = Color.Black;
            txtHighlightColor = Color.Transparent;
            txtBullet = false;
            txtAlign = HorizontalAlignment.Left;

            fontFamily = new FontFamily("Roboto");
            fontWeight = FontStyle.Regular;
            fontItallic = FontStyle.Regular;
            fontUnderline = FontStyle.Regular;
            fontStrike = FontStyle.Regular;
        }

        public void updateSelectedText(RichTextBox rtb)
        {
            rtb.SelectionFont = new Font(fontFamily, txtSize, fontWeight | fontItallic | fontUnderline | fontStrike);
            rtb.SelectionColor = txtColor;
            rtb.SelectionBackColor = txtHighlightColor;
            rtb.SelectionBullet = txtBullet;
            rtb.SelectionAlignment = txtAlign;
        }

        public void updateTextFormatManager(RichTextBox rtb)
        {
            if (rtb.SelectionFont == null)
            {
                
            }
            else
            {
                fontFamily = rtb.SelectionFont.FontFamily;

                if (rtb.SelectionFont.Bold)
                {
                    fontWeight = FontStyle.Bold;
                }
                else
                {
                    fontWeight = FontStyle.Regular;
                }

                if (rtb.SelectionFont.Italic)
                {
                    fontItallic = FontStyle.Italic;
                }
                else
                {
                    fontItallic = FontStyle.Regular;
                }

                if (rtb.SelectionFont.Underline)
                {
                    fontUnderline = FontStyle.Underline;
                }
                else
                {
                    fontUnderline = FontStyle.Regular;
                }

                if (rtb.SelectionFont.Strikeout)
                {
                    fontStrike = FontStyle.Strikeout;
                }
                else
                {
                    fontStrike = FontStyle.Regular;
                }

                txtSize = (int)rtb.SelectionFont.Size;
                txtColor = rtb.SelectionColor;
                txtHighlightColor = rtb.SelectionBackColor;
                txtBullet = rtb.SelectionBullet;
                txtAlign = rtb.SelectionAlignment;
            }
        }

        public void updateTextFormatMenu(List<Control> textFormatMenu)
        {
            foreach (Control ctrl in textFormatMenu)
            {
                switch (ctrl.Name)
                {
                    case "FontFamilyComboBox":
                        ComboBox fontFamilyComboBox = (ComboBox)ctrl;
                        fontFamilyComboBox.Text = fontFamily.ToString();
                        break;

                    case "FontSizeComboBox":
                        ComboBox textFormatComboBox = (ComboBox)ctrl;
                        textFormatComboBox.Text = txtSize.ToString();
                        break;
                }
            }
        }
    }
}
