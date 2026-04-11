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
    }
}
