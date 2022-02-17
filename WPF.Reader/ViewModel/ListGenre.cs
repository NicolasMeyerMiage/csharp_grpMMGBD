using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListGenre : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().UpdateGenreList();

        public ListGenre()
        {
            ItemSelectedCommand = new RelayCommand(genre => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsGenre>(genre); });
        }

    }
}
