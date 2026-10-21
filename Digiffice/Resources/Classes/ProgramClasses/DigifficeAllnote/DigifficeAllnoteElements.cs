using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;
using DigifficeWPFControls;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote
{
    public class DigifficeAllnoteElements
    {
        public enum ElementTypes
        {
            RTB = 0,
            DraggableSizablePictureBox = 1,
            InsertTable = 2
        }

        public class ElementHeader
        {
            public ElementTypes elementType { get; set; }
            public object element { get; set; }
        }

        public class RTBElement
        {
            public string? rtf { get; set; }
            public Size pnlSize { get; set; }
            public Size rtbSize { get; set; }
            public Point location { get; set; }
        }

        public class DraggableSizablePictureBoxElement
        {
            public BitmapSource image { get; set; }
            public string fmt { get; set; }
            public Point location { get; set; }
            public Size size { get; set; }
        }

        public class InsertTableElement
        {
            public Size pnlSize { get; set; }
            public Size tableSize { get; set; }
            public Point location { get; set; }
        }

        public RTBElement convertControlToRTB(Panel rtbPnl, RichTextBox rtb)
        {
            RTBElement rtbElement = new RTBElement();
            rtbElement.rtf = rtb.Rtf;
            rtbElement.location = rtbPnl.Location;
            rtbElement.pnlSize = rtbPnl.Size;
            rtbElement.rtbSize = rtb.Size;

            return rtbElement;
        }

        public DraggableSizablePictureBoxElement convertControlToDSPB(ElementHost elementHost)
        {
            DraggableSizablePicturebox dspb = (DraggableSizablePicturebox)elementHost.Child;
            DraggableSizablePictureBoxElement dspbElement = new DraggableSizablePictureBoxElement();

            dspbElement.image = dspb.baseImg.Source as BitmapSource;
            dspbElement.fmt = dspb.Tag as string;
            dspbElement.location = elementHost.Location;

            return dspbElement;
        }

        public InsertTableElement convertControlToInsertTable(Panel tablePnl, DataGridView table)
        {
            InsertTableElement tableElement = new InsertTableElement();
            tableElement.pnlSize = tablePnl.Size;
            tableElement.tableSize = table.Size;
            tableElement.location = tablePnl.Location;
            return tableElement;
        }
    }
}
