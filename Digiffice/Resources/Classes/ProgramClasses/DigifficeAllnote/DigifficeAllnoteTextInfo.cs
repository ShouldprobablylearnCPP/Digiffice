using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote
{
    public class DigifficeAllnoteTextInfo
    {
        // Class Variables
        public int txtSize = 8;
        public Color txtColor = Color.Black;
        public Color txtHighlightColor = Color.Transparent;
        public bool txtBullet = false;

        public FontFamily fontFamily = new FontFamily("Roboto");
        public FontStyle fontWeight = FontStyle.Regular;
        public FontStyle fontItallic = FontStyle.Regular;
        public FontStyle fontUnderline = FontStyle.Regular;
        public FontStyle fontStrike = FontStyle.Regular;

        // Presenter
        public void updateSelectedText(RichTextBox rtb)
        {

        }

        public void updateTextFormatMenu()
        {

        }
    }
}
