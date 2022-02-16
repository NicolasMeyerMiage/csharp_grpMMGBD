using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF = new Genre() { Id = 1, Title = "SF" };
            Genre Classic = new Genre() { Id = 2, Title = "Classic" };
            Genre Romance = new Genre() { Id = 3, Title = "Romance" };
            Genre Thriller = new Genre() { Id = 4, Title = "Thriller" };
            bookDbContext.Genre.AddRange(

                SF, Classic, Romance, Thriller

            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Author = "Thomas Fernand", Title = "La Marquise de New Paris", Genres = new List<Genre>() { SF, Classic }, Price = 24.99F, Contenu = "L'année est 1849 mais dans le futur." },
                new Book() { Author = "Emile Zozo", Title = "Les Fleurs du MAAAAAAAAAL", Genres = new List<Genre>() { Classic }, Price = 19.99F, Contenu = "Vive la mort." },
                new Book() { Author = "Françoise Delarue", Title = "L'amour Improbable", Genres = new List<Genre>() { Romance }, Price = 27.50F, Contenu = "Je vous aime !\nMoi non plus!\n:'(" },
                new Book() { Author = "Wielfried von Garner", Title = "Der Hund", Genres = new List<Genre>() { Thriller }, Price = 14.99F, Contenu = "Woof Woof Woof Woof." }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}