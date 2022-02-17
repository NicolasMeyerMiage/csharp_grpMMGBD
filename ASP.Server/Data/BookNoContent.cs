using System;
using System.Collections.Generic;


namespace ASP.Server.Model
{
    public class BookNoContent
    {
        public BookNoContent(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Price = book.Price;
            Genres = book.Genres;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
