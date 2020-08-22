using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Test1
{
    /// <summary>
    /// Interaction logic for ColourDragRandom.xaml
    /// </summary>
    public partial class ColourDragRandom : UserControl
    {
        private Random _rand = new Random();
        private List<Brush> _brushes = new List<Brush>
        {
            Brushes.Red,
            Brushes.Green,
            Brushes.Yellow,
            Brushes.Blue,
            Brushes.Magenta,
            Brushes.Cyan,
        };

        public Brush Fill
        {
            get { return RectangleUI.Fill; }
            set { RectangleUI.Fill = value; }
        }
        public ColourDragRandom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initiates drag event with a random fill colour from the brushes list as HEX colour string (i.e. #FFFFFF)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectangleUI_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (rect != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var brush = _brushes[_rand.Next(0, _brushes.Count - 1)];
                DragDrop.DoDragDrop(rect, brush.ToString(), DragDropEffects.Copy);
            }
        }
    }
}
