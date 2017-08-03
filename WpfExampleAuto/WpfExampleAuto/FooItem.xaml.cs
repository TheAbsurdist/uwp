using System.Windows;
using System.Windows.Controls;

namespace WpfExampleAuto
{
    public partial class FooItem : UserControl
    {
        public FooItem()
        {
            InitializeComponent();

            Unloaded += FooItem_Unloaded;
        }

        private void FooItem_Unloaded(object sender, RoutedEventArgs e)
        {
            DataContext = null;
        }
    }
}
