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
                new Book() { Author = "Thomas Fernand", Title = "La Marquise de New Paris", Genres = new() { SF, Classic }, Price = 24.99F, Contenu = @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit.Aliquam eu imperdiet ligula, vel pulvinar tortor.In egestas nec dolor quis molestie.Aenean rhoncus consequat consequat.Nulla id luctus tellus, sit amet convallis ante.Donec iaculis ut tellus eu aliquam.Vestibulum a molestie tortor.Suspendisse aliquet fermentum quam eu aliquam.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Sed dignissim dolor sem, at faucibus ex luctus ac. Fusce metus metus, ornare nec turpis ac, hendrerit lacinia mauris. Curabitur porttitor ut ante sit amet porttitor.Ut tristique blandit nunc, venenatis fermentum orci faucibus ac. Phasellus vestibulum ligula tellus, id sodales velit fermentum sed. Nullam tempus urna nec posuere interdum. Suspendisse vitae porta nibh, in lobortis leo.
Donec lacinia lobortis ante, viverra porttitor sapien mollis a. Aenean faucibus commodo egestas. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Cras ac finibus orci, eu placerat tellus. Vestibulum tempus dolor eu imperdiet bibendum. Nulla auctor lectus auctor nulla volutpat, sed vehicula arcu varius.Nunc sed tellus sed odio vehicula porta ut eleifend ligula. Morbi vel erat non erat laoreet condimentum quis at quam. Vestibulum eget ante varius, convallis magna in, porta dolor. Aenean ut leo efficitur, accumsan enim vel, bibendum risus.Integer feugiat, urna et elementum congue, magna leo feugiat dui, eu interdum risus metus vel ligula.Morbi cursus quam nec odio rutrum tempus.Fusce pellentesque ligula augue, et fringilla turpis molestie id. Morbi malesuada, diam eu convallis fringilla, ante leo tincidunt sem, vel pellentesque dui dolor at enim.Aliquam suscipit, nunc sed lacinia imperdiet, ante ligula ultrices leo, vel auctor purus tellus ut dui.Nunc ullamcorper bibendum nunc non facilisis.
Curabitur mollis, urna ut pretium convallis, mauris nisl condimentum eros, eget lobortis elit ex eget mi.Vivamus bibendum feugiat augue. Aliquam malesuada nisi et quam imperdiet, eu feugiat urna aliquet.Ut vulputate neque non orci vestibulum ultricies et quis metus. Vivamus vitae purus sapien. Aliquam sed bibendum libero, elementum semper enim. Vivamus malesuada justo sit amet vulputate feugiat.Aliquam elit ex, finibus ac tortor id, suscipit imperdiet mauris. Suspendisse quis dignissim sapien. Maecenas quam augue, luctus at lectus ut, auctor suscipit risus. Ut dapibus varius massa vel molestie. In eget nunc feugiat, commodo ex in, eleifend enim. Nunc laoreet imperdiet odio, eget sagittis arcu accumsan a. Curabitur venenatis mauris vitae lorem sollicitudin, nec ultricies elit rhoncus.
Etiam pulvinar dictum aliquet. Mauris vestibulum felis ex, vel sodales orci tincidunt non. Suspendisse tempor erat et diam convallis porttitor.Proin dui eros, accumsan a arcu ut, tincidunt viverra mi. Etiam eget dui a quam scelerisque convallis.Donec sed fringilla purus. Suspendisse id elementum turpis, a consequat tellus. Maecenas vel ex quis magna pharetra venenatis ac ac leo. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Nunc scelerisque massa justo, in tempus mi blandit ut. Quisque aliquam ut ante et tincidunt. Interdum et malesuada fames ac ante ipsum primis in faucibus.Praesent lobortis, ligula nec tristique lobortis, quam lorem dapibus nulla, in aliquet risus eros et lorem.Suspendisse a sem interdum, facilisis tortor vitae, viverra dui.Praesent maximus, ex vel maximus rhoncus, libero tellus facilisis risus, et aliquet dolor turpis vel justo.Nullam congue, est at rutrum pellentesque, turpis mi tristique mauris, convallis gravida nisi magna nec mauris.
Donec sodales eu lorem eu varius. Sed porta tellus urna, eget placerat tellus finibus id. Cras eget porttitor nulla. Vestibulum vitae pellentesque tellus. Maecenas consequat magna ut facilisis aliquet. In venenatis ultricies scelerisque. Quisque ultricies nulla ut mi mattis bibendum.Nulla dapibus a arcu efficitur lobortis. Aenean convallis metus eu nisi porttitor tristique.Donec id pellentesque mauris." },
                new Book() { Author = "Emile Zozo", Title = "Les Fleurs du MAAAAAAAAAL", Genres = new() { Classic }, Price = 19.99F, Contenu = "Vive la mort." },
                new Book() { Author = "Françoise Delarue", Title = "L'amour Improbable", Genres = new() { Romance }, Price = 27.50F, Contenu = "Je vous aime !\nMoi non plus!\n:'(" },
                new Book() { Author = "Wielfried von Garner", Title = "Der Hund", Genres = new() { Thriller }, Price = 14.99F, Contenu = "Woof Woof Woof Woof." },
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