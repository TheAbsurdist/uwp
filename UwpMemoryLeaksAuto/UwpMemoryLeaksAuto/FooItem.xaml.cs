using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpMemoryLeaksAuto
{
    public sealed partial class FooItem : UserControl
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
