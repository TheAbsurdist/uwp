using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfExampleAuto
{
    public abstract class BaseObservable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FooViewModel : BaseObservable
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private int magic;
        public int Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                OnPropertyChanged();
            }
        }
    }

    public class ContentViewModel : BaseObservable
    {
        private ObservableCollection<FooViewModel> items = new ObservableCollection<FooViewModel>();
        public ObservableCollection<FooViewModel> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        private int counter;

        public ContentViewModel(int nitems)
        {
            for (int i = 0; i < nitems; i++)
            {
                Items.Add(CreateFoo());
            }
        }

        private FooViewModel CreateFoo()
        {
            counter++;
            var item = new FooViewModel()
            {
                Title = $"Foo{counter}",
                Magic = counter,
            };

            return item;
        }
    }
}
