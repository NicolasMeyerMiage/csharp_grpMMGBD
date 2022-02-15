using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;
using System.Diagnostics;

namespace ASP.Server.Api
{

    [Route("/api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }


        // - GetBooks
        //   - Entrée: Optionel -> Liste d'Id de genre, limit -> defaut à 10, offset -> défaut à 0
        //     Le but de limit et offset est dé créer un pagination pour ne pas retourner la BDD en entier a chaque appel
        //   - Sortie: Liste d'object contenant uniquement: Auteur, Genres, Titre, Id, Prix
        //     la liste restourner doit être compsé des élément entre <offset> et <offset + limit>-
        //     Dans [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20] si offset=8 et limit=5, les élément retourner seront : 8, 9, 10, 11, 12

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Book>> GetBooks(int limit=10, int offset=0, int? genre=null)
        {
            try
            {
                return Ok(libraryDbContext.Books.Select(x => x).Include(x => x.Genres).Skip(offset).Take(limit).ToList());
                /*if(genre == null)
                    return Ok(libraryDbContext.Books.Select(x => x).Include(x => x).Skip(offset).Take(limit).ToList());

                return Ok(libraryDbContext.Books.Where(x => x.Genres.Contains(libraryDbContext.Genre.Find(genre)))
                    .Include(x => x.Genres)
                    .Skip(offset).Take(limit).ToList());
                */
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e);
                return NotFound();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return NotFound();
            }
                
        }


        // - GetBook
        //   - Entrée: Id du livre
        //   - Sortie: Object livre entier

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> GetBookById(int id)
        {
            try
            {
                Book book = libraryDbContext.Books.Include(x => x.Genres).Single(book => book.Id == id);
                return Ok(book);
                /*
                if (book != null)
                    return Ok(book);
                else
                    return NotFound();
                */
            }
            catch(InvalidOperationException e)
            {
                Debug.WriteLine(e);
                return NotFound();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return NotFound();
            }
            

        }

    }
}

