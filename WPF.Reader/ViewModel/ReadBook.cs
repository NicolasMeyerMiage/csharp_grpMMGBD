using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    public class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Book CurrentBook { get; init; }

        public ReadBook(BookNoContent book)
        {
            CurrentBook = Ioc.Default.GetRequiredService<LibraryService>().GetBookFromID(book.Id);
        }
    }
}
