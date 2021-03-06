using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Reader.Model
{
    // A vous de completer ce qu'est un Livre !!
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public string Contenu { get; set; }
        public List<Genre> Genres { get; set; }

        public Book(int id, string title, string author, float price, string contenu, List<Genre> genres)
        {   
            Id = id;
            Title = title;
            Author = author;
            Price = price;
            Contenu = contenu;
            Genres = genres;
        }
        public Book()
        {

        }
    }
}
