using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigifficeWPFControls
{
    /// <summary>
    /// Interaction logic for DraggableSizablePicturebox.xaml
    /// </summary>
    public partial class DraggableSizablePicturebox : UserControl
    {
        // Variables
        public bool IsTransforming { get; set; } = false;
        public bool IsDragging { get; set; } = false;

        public DraggableSizablePicturebox()
        {
            InitializeComponent();
            this.Background = Brushes.White;
        }

        public Image baseImg => BaseImg;
        public Button topLeftResizer => TopLeftResizer;
        public Button topResizer => TopResizer;
        public Button topRightResizer => TopRightResizer;
        public Button bottomLeftResizer => BottomLeftResizer;
        public Button bottomResizer => BottomResizer;
        public Button bottomRightResizer => BottomRightResizer;
        public Button leftResizer => LeftResizer;
        public Button rightResizer => RightResizer;

        // Events
        private void baseImg_ImgChanged(object sender, DataTransferEventArgs e)
        {
            baseImg.Width = baseImg.Source.Width;
            baseImg.Height = baseImg.Source.Height;

            this.Width = baseImg.Width + 5; // Add some padding for the resizers
            this.Height = baseImg.Height + 5; // Add some padding for the resizers
        }

        private void BaseImg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsTransforming)
            {
                // Hide the resizers when the user finishes transforming
                topLeftResizer.Visibility = Visibility.Hidden;
                topResizer.Visibility = Visibility.Hidden;
                topRightResizer.Visibility = Visibility.Hidden;
                bottomLeftResizer.Visibility = Visibility.Hidden;
                bottomResizer.Visibility = Visibility.Hidden;
                bottomRightResizer.Visibility = Visibility.Hidden;
                leftResizer.Visibility = Visibility.Hidden;
                rightResizer.Visibility = Visibility.Hidden;
                IsTransforming = false;
            }
            else
            {
                // Show the resizers when the user clicks on the image
                topLeftResizer.Visibility = Visibility.Visible;
                topResizer.Visibility = Visibility.Visible;
                topRightResizer.Visibility = Visibility.Visible;
                bottomLeftResizer.Visibility = Visibility.Visible;
                bottomResizer.Visibility = Visibility.Visible;
                bottomRightResizer.Visibility = Visibility.Visible;
                leftResizer.Visibility = Visibility.Visible;
                rightResizer.Visibility = Visibility.Visible;
                IsTransforming = true;
            }
        }
    }
}
