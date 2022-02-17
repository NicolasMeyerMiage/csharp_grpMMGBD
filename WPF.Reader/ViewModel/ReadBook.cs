using System.ComponentModel;
using WPF.Reader.Model;

namespace WPF.Reader.ViewModel
{
    public class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Book CurrentBook { get; init; }

        public ReadBook(Book book)
        {
            CurrentBook = book;
        }
    }
}
