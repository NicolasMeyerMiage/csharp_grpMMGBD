using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBooks : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }

        // n'oublier pas faire de faire le binding dans ListBooks.xaml !!!!
        public BookList BookList => Ioc.Default.GetRequiredService<LibraryService>().UpdateBookList(CurrentPage, Genre);

        public ListBooks(int CurrentPage=1, Genre genre=null)
        {
            Genre = genre;
            this.CurrentPage = CurrentPage;
            ItemSelectedCommand = new RelayCommand(book => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book); });
            PreviousPageCommand = new RelayCommand(currentPage => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListBooks>((int)currentPage-1, genre); }, _ => CurrentPage > 1);
            NextPageCommand = new RelayCommand(currentPage => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListBooks>((int)currentPage+1, genre); }, _ => CurrentPage < Math.Floor((BookList.BooksNumber-1) / 10.0)+1);
        }

        public ListBooks() : this(1) { }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public Genre Genre;

        public int CurrentPage { get; set; }
    }
}
