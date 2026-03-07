using System.Text;
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
    public partial class SizableDraggablePictureBox : UserControl
    {
        // Publicise child elements for external use
        public Image imageControl => Img;
        public Button topLeftResizer => TopLeftResizer;
        public Button middleLeftResizer => MiddleLeftResizer;
        public Button bottomLeftResizer => BottomLeftResizer;
        public Button topRightResizer => TopRightResizer;
        public Button middleRightResizer => MiddleRightResizer;
        public Button bottomRightResizer => BottomRightResizer;
        public Button topMiddleResizer => TopMiddleResizer;
        public Button bottomMiddleResizer => BottomMiddleResizer;

        public SizableDraggablePictureBox()
        {
            InitializeComponent();
        }
    }

}
