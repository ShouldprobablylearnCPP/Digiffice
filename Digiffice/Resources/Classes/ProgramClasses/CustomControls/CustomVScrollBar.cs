using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.CustomControls
{
    public class CustomVScrollBar
    {
        public Control ctrlToAdd;

        // Control Cols
        public Color scrollBarBgCol = Color.White;
        public Color upScrollBtnCol = Color.White;
        public Color downScrollBtnCol = Color.White;
        public Color scrollBarCol = Color.LightGray;

        // Control Images
        public Image? scrollBarBgImg = null;
        public Image? upScrollBtnImg = null;
        public Image? downScrollBtnImg = null;
        public Image? scrollBarImg = null;
        public CustomVScrollBar(Point rectLocation, Size rectsize, 
            Color scrollBarBgCol, Color upScrollBtnCol, Color downScrollBtnCol, Color scrollBarCol, 
            Image? scrollBarBgImg, Image? upScrollBtnImg, Image? downScrollBtnImg, Image? scrollBarImg)
        {
            // Parent Control Properties
            Panel ScrollBarBgPnl = new Panel();
            ScrollBarBgPnl.Location = rectLocation;
            ScrollBarBgPnl.Size = rectsize;
            ScrollBarBgPnl.BackColor = scrollBarBgCol;
            if (scrollBarBgImg != null)
            {
                ScrollBarBgPnl.BackgroundImage = scrollBarBgImg;
            }

            // L+R Button Properties
            Button UpScrollBtn = new Button();
            UpScrollBtn.Size = new Size(rectsize.Width, rectsize.Width);
            UpScrollBtn.Location = new Point(0, 0);
            UpScrollBtn.BackColor = upScrollBtnCol;
            UpScrollBtn.FlatStyle = FlatStyle.Flat;
            UpScrollBtn.FlatAppearance.BorderSize = 0;
            UpScrollBtn.Cursor = Cursors.Hand;
            UpScrollBtn.Click += UpScrollBtn_Click;
            if (upScrollBtnImg != null)
            {
                UpScrollBtn.BackgroundImage = upScrollBtnImg;
            }

            Button DownScrollBtn = new Button();
            DownScrollBtn.Size = new Size(rectsize.Width, rectsize.Width);
            DownScrollBtn.Location = new Point(0, rectsize.Height - rectsize.Width);
            DownScrollBtn.BackColor = downScrollBtnCol;
            DownScrollBtn.FlatStyle = FlatStyle.Flat;
            DownScrollBtn.FlatAppearance.BorderSize = 0;
            DownScrollBtn.Cursor = Cursors.Hand;
            DownScrollBtn.Click += DownScrollBtn_Click;
            if (downScrollBtnImg != null)
            {
                DownScrollBtn.BackgroundImage = downScrollBtnImg;
            }

            ScrollBarBgPnl.Controls.Add(UpScrollBtn);
            ScrollBarBgPnl.Controls.Add(DownScrollBtn);

            // Scroll Bar Properties
            Panel ScrollBarPnl = new Panel();
            ScrollBarPnl.Size = new Size(rectsize.Width, rectsize.Width * 2);
            ScrollBarPnl.Location = new Point(0, UpScrollBtn.Size.Width);
            ScrollBarPnl.BackColor = scrollBarCol;
            if (scrollBarImg != null)
            {
                ScrollBarPnl.BackgroundImage = scrollBarImg;
            }

            ScrollBarBgPnl.Controls.Add(ScrollBarPnl);
            ctrlToAdd = ScrollBarBgPnl;
        }

        public void UpScrollBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DownScrollBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void addControlstoControl(Control control)
        {
            control.Controls.Add(ctrlToAdd);
        }

        public void addControlstoForm(Form form)
        {
            form.Controls.Add(ctrlToAdd);
        }
    }
}
