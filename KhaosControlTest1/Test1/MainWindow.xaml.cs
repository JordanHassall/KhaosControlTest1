using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Test1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> _itemList = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            ItemList.ItemsSource = _itemList;
        }


        /// <summary>
        /// Fills the itemlist if it hasn't already been filled, does nothing if it has.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillListButton_Click(object sender, RoutedEventArgs e)
        {
            if (_itemList.Count == 0)
            {
                for (int i = 0; i < 100; ++i)
                {
                    _itemList.Add($"This is item number {i}");
                }
            }
        }

        /// <summary>
        /// Gets the data from the drag event converts it to it's brush equivalent and sets the dropped onto items background
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItem_Drop(object sender, DragEventArgs e)
        {
            ListViewItem listViewItem = sender as ListViewItem;

            if (listViewItem != null && e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string data = (string)e.Data.GetData(DataFormats.StringFormat);
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(data))
                {
                    listViewItem.Background = (Brush)converter.ConvertFromString(data);
                }
            }
        }
    }
}
