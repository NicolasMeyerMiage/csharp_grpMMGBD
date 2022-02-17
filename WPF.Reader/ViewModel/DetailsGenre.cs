using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    public class DetailsGenre : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Genre CurrentGenre { get; init; }

        public DetailsGenre(Genre genre)
        {
            CurrentGenre = genre;
        }
    }

}
