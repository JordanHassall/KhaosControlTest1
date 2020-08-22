using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Test1
{
    /// <summary>
    /// Colour drop rectangle with drag source functionality to copy the colour
    /// </summary>
    public partial class ColourDrag : UserControl
    {
        public Brush Fill
        {
            get { return RectangleUI.Fill; }
            set { RectangleUI.Fill = value; }
        }

        public ColourDrag()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Initiates drag event with current fill colour as HEX colour string (i.e. #FFFFFF)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectangleUI_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (rect != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(rect, rect.Fill.ToString(), DragDropEffects.Copy);
            }
        }
    }
}
