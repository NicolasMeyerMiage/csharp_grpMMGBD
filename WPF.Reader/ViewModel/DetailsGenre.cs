using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    public class DetailsGenre : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        public Genre CurrentGenre { get; init; }

        public DetailsGenre(Genre genre)
        {
            CurrentGenre = genre;
            CurrentGenre.Title = $"Liste des livres du genre {CurrentGenre.Title}";
            ItemSelectedCommand = new RelayCommand(book => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book); });
        }
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().UpdateBookByGenreList(CurrentGenre);


    }

}
