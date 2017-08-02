using System;
using System.Windows;

namespace WpfExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void showPage_Click(object sender, RoutedEventArgs e)
        {
            container.Content = new ContentControl();
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
