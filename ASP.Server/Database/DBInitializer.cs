﻿using Microsoft.AspNetCore.Identity;
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

            Genre SF, Classic, Romance, Thriller;
            bookDbContext.Genre.AddRange(
                SF = new Genre() { Type = "Science Fiction" },
                Classic = new Genre() { Type = "Classic" },
                Romance = new Genre() { Type = "Romance" },
                Thriller = new Genre() { Type = "Thriller" }
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Author = "Thomas Fernand", Title = "La Marquise de New Paris", Genres = new() { SF, Classic }, Price = 24.99F, Contenu = "L'année est 1849 mais dans le futur." },
                new Book() { Author = "Emile Zozo", Title = "Les Fleurs du MAAAAAAAAAL", Genres = new() { Classic }, Price = 19.99F, Contenu = "Vive la mort." },
                new Book() { Author = "Françoise Delarue", Title = "L'amour Improbable", Genres = new() { Romance }, Price = 27.50F, Contenu = "Je vous aime !\nMoi non plus!\n:'(" },
                new Book() { Author = "Wielfried von Garner", Title = "Der Hund", Genres = new() { Thriller }, Price = 14.99F, Contenu = "Woof Woof Woof Woof." }
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}