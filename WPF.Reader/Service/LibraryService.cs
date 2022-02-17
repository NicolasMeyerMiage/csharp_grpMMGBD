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
        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>();

        public BookList UpdateBookList(int page, Genre genre)
        {
             HttpClient client = new HttpClient();
             client.BaseAddress = new Uri("https://localhost:5001");
             HttpResponseMessage response = client.GetAsync("/api/book?offset="+((page-1)*10)+(genre != null ? "&genreId="+genre.Id : "")).Result;
             if (response.IsSuccessStatusCode)
             {
                  string result = response.Content.ReadAsStringAsync().Result; 
                  BookList listBooks = JsonConvert.DeserializeObject<BookList>(result);

                  return listBooks;
             }

            return new BookList();
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

        public Book GetBookFromID(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = client.GetAsync("/api/book/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Book listBooks = JsonConvert.DeserializeObject<Book>(result);

                return listBooks;
            }

            return new Book();
        }
    }
}
