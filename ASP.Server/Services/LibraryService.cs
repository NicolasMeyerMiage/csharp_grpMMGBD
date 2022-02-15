using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Server.Service
{
    public class LibraryService
    {
        private readonly LibraryDbContext libraryDbContext;

        public LibraryService(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        // Ajouter ici toutes vos fonctions qui peuvent être accéder a différent endroit de votre programme
        public IEnumerable<Genre> getListGenres()
        {
            return libraryDbContext.Genre.ToList();
        }
    }
}
