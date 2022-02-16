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
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouer et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() {
            new Book(),
            new Book(),
            new Book()
        };

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
            //List<Book> books = new List<Book>();
            
            // books = // call to api
            // books.CopyTo(Books);
        }

        // C'est aussi ici que vous ajouterez les requète réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
    }
}
