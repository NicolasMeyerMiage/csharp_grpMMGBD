using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    public class DetailsBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ReadCommand { get; set; }

        public BookNoContent CurrentBook { get; init; }

        public DetailsBook(BookNoContent book)
        {
            CurrentBook = book;
            ReadCommand = new RelayCommand(ContenuBook => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ReadBook>(book); });
        }

    }

}
