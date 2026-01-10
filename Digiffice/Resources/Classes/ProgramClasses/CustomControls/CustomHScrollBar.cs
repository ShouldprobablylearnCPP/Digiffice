using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.CustomControls
{
    public class CustomHScrollBar
    {
        public Control ctrlToAdd;

        public int minVal = 0;
        public int maxVal = 0;
        public int range = 0;
        public int currentVal = 0;
        public int minX = 0;
        public int maxX = 0;

        public bool scrollbar_isDragging = false;

        Panel Scrollbar;

        public CustomHScrollBar(Point rectLocation, Size rectsize,
            Color scrollBarBgCol, Color leftScrollBtnCol, Color rightScrollBtnCol, Color scrollBarCol,
            Image? scrollBarBgImg, Image? leftScrollBtnImg, Image? rightScrollBtnImg, Image? scrollBarImg)
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
            ScrollBarBgPnl.MouseClick += ScrollBarBgPnl_Click;

            // L+R Button Properties
            Button LeftScrollBtn = new Button();
            LeftScrollBtn.Size = new Size(rectsize.Height, rectsize.Height);
            LeftScrollBtn.Location = new Point(0, 0);
            LeftScrollBtn.BackColor = leftScrollBtnCol;
            LeftScrollBtn.FlatStyle = FlatStyle.Flat;
            LeftScrollBtn.FlatAppearance.BorderSize = 0;
            LeftScrollBtn.Cursor = Cursors.Hand;
            LeftScrollBtn.Click += LeftScrollBtn_Click;
            if (leftScrollBtnImg != null)
            {
                LeftScrollBtn.BackgroundImage = leftScrollBtnImg;
            }

            Button RightScrollBtn = new Button();
            RightScrollBtn.Size = new Size(rectsize.Height, rectsize.Height);
            RightScrollBtn.Location = new Point(rectsize.Width - rectsize.Height, 0);
            RightScrollBtn.BackColor = rightScrollBtnCol;
            RightScrollBtn.FlatStyle = FlatStyle.Flat;
            RightScrollBtn.FlatAppearance.BorderSize = 0;
            RightScrollBtn.Cursor = Cursors.Hand;
            RightScrollBtn.Click += RightScrollBtn_Click;
            if (rightScrollBtnImg != null)
            {
                RightScrollBtn.BackgroundImage = rightScrollBtnImg;
            }

            ScrollBarBgPnl.Controls.Add(LeftScrollBtn);
            ScrollBarBgPnl.Controls.Add(RightScrollBtn);

            // Scroll Bar Properties
            Panel ScrollBarPnl = new Panel();
            ScrollBarPnl.Size = new Size(rectsize.Height * 4, rectsize.Height);
            ScrollBarPnl.Location = new Point(LeftScrollBtn.Size.Width, 0);
            ScrollBarPnl.BackColor = scrollBarCol;
            if (scrollBarImg != null)
            {
                ScrollBarPnl.BackgroundImage = scrollBarImg;
            }
            Scrollbar = ScrollBarPnl;
            ScrollBarPnl.MouseDown += Scrollbar_MouseDown;
            ScrollBarPnl.MouseMove += Scrollbar_MouseMove;
            ScrollBarPnl.MouseUp += Scrollbar_MouseUp;

            // Init function vars
            minX = LeftScrollBtn.Width;
            maxX = rectsize.Width - (RightScrollBtn.Size.Width + ScrollBarPnl.Width);

            // Prepare control to add
            ScrollBarBgPnl.Controls.Add(ScrollBarPnl);
            ctrlToAdd = ScrollBarBgPnl;
        }

        // Event Handlers

        public void ScrollBarBgPnl_Click(object sender, MouseEventArgs e)
        {
            Panel ScrollBarBgPanel = (Panel)sender;
            int newX = e.X - (Scrollbar.Width / 2);
            Scrollbar.Location = new Point(Math.Clamp(newX, minX, maxX), Scrollbar.Location.Y);
            setcurrentVal();
        }
        public void LeftScrollBtn_Click(object sender, EventArgs e)
        {
            int change = (maxX - minX) / 10;
            Scrollbar.Location = new Point(Math.Max(Scrollbar.Location.X - change, minX), Scrollbar.Location.Y);
            if (Scrollbar.Location.X - change < minX)
            {
                Scrollbar.Location = new Point(minX, Scrollbar.Location.Y);
            }
            setcurrentVal();
        }

        public void RightScrollBtn_Click(object sender, EventArgs e)
        {
            int change = (maxX - minX) / 10;
            Scrollbar.Location = new Point(Math.Min(Scrollbar.Location.X + change, maxX), Scrollbar.Location.Y);
            if (Scrollbar.Location.X + change > maxX)
            {
                Scrollbar.Location = new Point(maxX, Scrollbar.Location.Y);
            }
            setcurrentVal();
        }

        private void Scrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            scrollbar_isDragging = false;
        }

        private void Scrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scrollbar_isDragging = true;
            }
        }

        private void Scrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (scrollbar_isDragging)
            {
                int newX = Scrollbar.Location.X + e.X - (Scrollbar.Width / 2);
                Scrollbar.Location = new Point(Math.Clamp(newX, minX, maxX), Scrollbar.Location.Y);
                setcurrentVal();
            }
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
            currentVal = minVal + (int)((((double)(ctrlToAdd.Controls[2].Location.X - minX)) / (double)(maxX - minX)) * (double)range);
        }

        public int getCurrentVal()
        {
            return currentVal;
        }
    }
}
