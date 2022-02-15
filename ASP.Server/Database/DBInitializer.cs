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
                new Book(), 
                new Book(),
                new Book(),
                new Book()
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}