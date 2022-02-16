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
                new Book() { Author = "aaa", Title = "titre1", Price = 10, Contenu = "contenu1", Genres = new() { Romance, Thriller } }, 
                new Book() { Author = "bbb", Title = "titre2", Price = 20, Contenu = "contenu2", Genres = new() { SF, Classic } },
                new Book() { Author = "ccc", Title = "titre3", Price = 30, Contenu = "contenu du fun", Genres = new() { Thriller, Classic } },
                new Book() { Author = "ddd", Title = "titre4", Price = 120, Contenu = "contenu3", Genres = new() { SF } },
                new Book() { Author = "eee", Title = "titre5", Price = 23, Contenu = "contenu pas fun", Genres = new() { Classic } },
                new Book() { Author = "fff", Title = "titre6", Price = 29, Contenu = "contenu5", Genres = new() { SF, Classic, Thriller } },
                new Book() { Author = "ggg", Title = "titre7", Price = 24, Contenu = "contenu", Genres = new() { SF, Classic, Thriller, Romance } },
                new Book() { Author = "hhh", Title = "titre8", Price = 26, Contenu = "contenant", Genres = new() { SF, Thriller, Classic } },
                new Book() { Author = "iii", Title = "titre9", Price = 32, Contenu = "content", Genres = new() { SF, Thriller, Romance, Classic } },
                new Book() { Author = "jjj", Title = "titre10", Price = 23.40F, Contenu = "con", Genres = new() { Romance } },
                new Book() { Author = "kkk", Title = "titre11", Price = 20.99F, Contenu = "tenu", Genres = new() { Thriller } },
                new Book() { Author = "bbb", Title = "titre12", Price = 20.34F, Contenu = "2", Genres = new() { Classic } }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}