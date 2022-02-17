using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF.Reader.Model;
using System.Net.Http;
using System;
using Newtonsoft.Json;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() {
            new Book(),
            new Book(),
            new Book()
        };

        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>();

        public ObservableCollection<Book> UpdateBookList()
        {
             Books.Clear();

             HttpClient client = new HttpClient();
             client.BaseAddress = new Uri("https://localhost:5001");
             HttpResponseMessage response = client.GetAsync("/api/book").Result; 
             if (response.IsSuccessStatusCode)
             {
                  string result = response.Content.ReadAsStringAsync().Result; 
                  List<Book> listBooks = JsonConvert.DeserializeObject<List<Book>>(result);
                  listBooks.ForEach(obj =>
                  {
                      Book book = new Book(obj.Id, obj.Title, obj.Author, obj.Price, obj.Contenu, obj.Genres);
                      Books.Add(book);
                      Console.WriteLine(book);
                  });
                  
             }

            return Books;
        }

        public ObservableCollection<Genre> UpdateGenreList()
        {
            Genres.Clear();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = client.GetAsync("/api/genre").Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                List<Genre> listGenres = JsonConvert.DeserializeObject<List<Genre>>(result);
                listGenres.ForEach(obj =>
                {
                    Genre genre = new Genre(obj.Id, obj.Title);
                    Genres.Add(genre);
                });

            }

            return Genres;
        }

        public ObservableCollection<Book> UpdateBookByGenreList(Genre genre)
        {
            Books.Clear();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = client.GetAsync("/api/book?genreId="+genre.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                List<Book> listBooks = JsonConvert.DeserializeObject<List<Book>>(result);
                listBooks.ForEach(obj =>
                {
                    Book book = new Book(obj.Id, obj.Title, obj.Author, obj.Price, obj.Contenu, obj.Genres);
                    Books.Add(book);
                    Console.WriteLine(book);
                });

            }

            return Books;
        }
    }
}
