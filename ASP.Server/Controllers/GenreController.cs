using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Service;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Controllers
{
    public class CreateGenreModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
    }
    public class GenreController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;
        private readonly LibraryService libraryService;

        public GenreController(LibraryDbContext libraryDbContext, LibraryService libraryService)
        {
            this.libraryDbContext = libraryDbContext;
            this.libraryService = libraryService;
        }

        // A vous de faire comme BookController.List mais pour les genres !
        public ActionResult<IEnumerable<Genre>> List()
        {
            // récupérer les genres dans la base de donées pour qu'ils puissent etre affiches
            return View(this.libraryService.getListGenres());

        }

        public ActionResult<CreateGenreModel> Create(CreateGenreModel genre)
        {

            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                List<Genre> Genres = libraryService.getListGenres().ToList();
                Boolean genreAlreadyadded= false;
                foreach (Genre it in Genres)
                {
                    if (it.Title.ToLower() == genre.Title.ToLower())
                    {
                        genreAlreadyadded = true; 
                    }
                }

                if (genreAlreadyadded == false)
                {
                    libraryDbContext.Add(new Genre()
                    {
                        Title = genre.Title
                    });
                    libraryDbContext.SaveChanges();
                    return View("List",this.libraryService.getListGenres());
                }
            }
            return View("Create", new CreateBookModel() { AllGenres = this.libraryService.getListGenres() });
        }
    }
}
