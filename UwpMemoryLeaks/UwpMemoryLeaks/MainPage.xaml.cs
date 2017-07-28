using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpMemoryLeaks
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void showPage_Click(object sender, RoutedEventArgs e)
        {
            container.Content = new ContentPage();
        }

        private void hidePage_Click(object sender, RoutedEventArgs e)
        {
            container.Content = null;
        }

        private void gc_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect(2, GCCollectionMode.Forced, true);
            GC.WaitForPendingFinalizers();
        }
    }
}
