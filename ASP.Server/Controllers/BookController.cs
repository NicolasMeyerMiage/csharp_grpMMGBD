using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using ASP.Server.Service;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ASP.Server.Controllers
{
    public class CreateBookModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Contenu { get; set; }

        [Display(Name = "Genres")]
        public List<int> Genres { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init;  }
    }

    public class EditBookModel
    {

        [Display(Name = "IdBookToEdit")]
        public int IdBookToEdit { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Contenu { get; set; }

      
        [Required]
        [Display(Name = "GenreToSelect")]
        public List<int> GenreToSelect { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init; }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;
        private readonly LibraryService libraryService;

        public BookController(LibraryDbContext libraryDbContext, LibraryService libraryService)
        {
            this.libraryDbContext = libraryDbContext;
            this.libraryService = libraryService;
        }

        public ActionResult<IEnumerable<Book>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Book> ListBooks = this.libraryDbContext.Books.Include(x => x.Genres).ToList();
            return View(ListBooks);
        }


        public ActionResult<CreateBookModel> Create(CreateBookModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                List<Genre> genres = new List<Genre>();
                    
                var idGenres = book.Genres.Where(genre =>
                {
                    return this.libraryDbContext.Genre.Select(_genre => _genre.Id == genre).Any();
                }).ToList();

                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                foreach (var id in idGenres)
                {
                    genres.Add(this.libraryDbContext.Genre.Find(id));
                }
                
                libraryDbContext.Add(new Book()
                {
                    Title=book.Title,
                    Author=book.Author,
                    Price=book.Price,
                    Contenu=book.Contenu,
                    Genres=genres
                });
                libraryDbContext.SaveChanges();
                return RedirectToAction("List");
            }

            DbSet<Genre> allGenres = this.libraryDbContext.Genre;
            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            // new CreateBookModel() { AllGenres = null }
            return View("Create", new CreateBookModel() { AllGenres = this.libraryService.getListGenres() });
        }

        [HttpPost("Book/Delete/{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Delete(int id)
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            Book book = this.libraryDbContext.Books.Single(book => book.Id == id);

            libraryDbContext.Books.Remove(book);
            libraryDbContext.SaveChanges();
            return RedirectPermanent("/Book/List");
        }

        [HttpGet("Book/Edit/{id}")]
        [HttpPost("Book/Edit/{id}")]
        public ActionResult<EditBookModel> Edit(int id, EditBookModel book)
        {
            Book currentBook = this.libraryDbContext.Books.Include(x => x.Genres).Single(book => book.Id == id);


            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                List<Genre> genres = new List<Genre>();
                
                var idGenres = book.GenreToSelect.Where(genre =>
                {
                    return this.libraryDbContext.Genre.Select(_genre => _genre.Id == genre).Any();
                }).ToList();

                foreach (var idGenre in idGenres)
                {
                    genres.Add(this.libraryDbContext.Genre.Find(idGenre));
                }

                currentBook.Title = book.Title;
                currentBook.Author = book.Author;
                currentBook.Price = book.Price;
                currentBook.Contenu = book.Contenu;
                currentBook.Genres = genres;
                
                libraryDbContext.SaveChanges();
                return RedirectToAction("List");
            }


            DbSet<Genre> allGenres = this.libraryDbContext.Genre;

            List<int> genreToSelect = new List<int>();
            foreach (Genre genre in currentBook.Genres)
            {
                genreToSelect.Add(genre.Id); 
            }

            EditBookModel bookToEdit = new EditBookModel() { 
                IdBookToEdit=currentBook.Id,
                Title=currentBook.Title,
                Author = currentBook.Author,
                Price = currentBook.Price,
                Contenu = currentBook.Contenu,
                GenreToSelect=genreToSelect, 
                AllGenres = this.libraryService.getListGenres()
            };

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            // new CreateBookModel() { AllGenres = null }
            return View("Edit", bookToEdit);
        }
    }
}
