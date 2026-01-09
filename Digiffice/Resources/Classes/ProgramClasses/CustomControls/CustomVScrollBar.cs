using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.CustomControls
{
    public class CustomVScrollBar
    {
        public Control ctrlToAdd;

        public int minVal = 0;
        public int maxVal = 0;
        public int range = 0;
        public int currentVal = 0;
        public int minY = 0;
        public int maxY = 0;

        Panel Scrollbar;

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
            ScrollBarPnl.Size = new Size(rectsize.Width, rectsize.Width * 4);
            ScrollBarPnl.Location = new Point(0, UpScrollBtn.Size.Width);
            ScrollBarPnl.BackColor = scrollBarCol;
            if (scrollBarImg != null)
            {
                ScrollBarPnl.BackgroundImage = scrollBarImg;
            }
            Scrollbar = ScrollBarPnl;

            // Init function vars
            minY = UpScrollBtn.Width;
            maxY = rectsize.Height - (DownScrollBtn.Size.Width + ScrollBarPnl.Height);

            // Prepare control to add
            ScrollBarBgPnl.Controls.Add(ScrollBarPnl);
            ctrlToAdd = ScrollBarBgPnl;
        }

        public void UpScrollBtn_Click(object sender, EventArgs e)
        {
            int change = (maxY - minY) / 10;
            Scrollbar.Location = new Point(Scrollbar.Location.X, Math.Max(Scrollbar.Location.Y - change, minY));
            if (Scrollbar.Location.Y - change < minY)
            {
                Scrollbar.Location = new Point(Scrollbar.Location.X, minY);
            }
            setcurrentVal();
        }

        public void DownScrollBtn_Click(object sender, EventArgs e)
        {
            int change = (maxY - minY) / 10;
            Scrollbar.Location = new Point(Scrollbar.Location.X, Math.Min(Scrollbar.Location.Y + change, maxY));
            if (Scrollbar.Location.Y + change > maxY)
            {
                Scrollbar.Location = new Point(Scrollbar.Location.X, maxY);
            }
            setcurrentVal();
        }

        public void addControlstoControl(Control control)
        {
            control.Controls.Add(ctrlToAdd);
        }

        public void addControlstoForm(Form form)
        {
            form.Controls.Add(ctrlToAdd);
        }

        public void setMinMaxRange(int min, int max)
        {
            this.minVal = min;
            this.maxVal = max;
            this.range = maxVal - minVal;
        }

        public void setcurrentVal()
        {
            currentVal = minVal + (int)((((double)(ctrlToAdd.Controls[2].Location.Y - minY)) / (double)(maxY - minY)) * (double)range);
        }

        public int getCurrentVal()
        {
            return currentVal;
        }
    }
}
