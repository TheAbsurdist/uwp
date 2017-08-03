using System.Windows;
using System.Windows.Controls;

namespace WpfExampleAuto
{
    public partial class ContentControl : UserControl
    {
        private ContentViewModel viewModel;

        public ContentControl()
        {
            InitializeComponent();
            Loaded += ContentPage_Loaded;
            Unloaded += ContentPage_Unloaded;
        }

        private void ContentPage_Unloaded(object sender, RoutedEventArgs e)
        {
            list.ItemsSource = null;
            viewModel = null;
        }

        private void ContentPage_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new ContentViewModel(10000);
            DataContext = viewModel;
        }
    }
}
