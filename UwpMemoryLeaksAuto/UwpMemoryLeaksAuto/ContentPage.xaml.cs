using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpMemoryLeaksAuto
{
    public sealed partial class ContentPage : Page
    {
        private ContentViewModel viewModel;

        public ContentPage()
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
