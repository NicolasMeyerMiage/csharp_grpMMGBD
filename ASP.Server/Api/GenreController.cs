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

    [Route("/api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        // - GetGenres
        //   - Entrée: Rien
        //   - Sortie: Liste des genres

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Genre> GetGenres()
        {
            try
            {
                return Ok(libraryDbContext.Genre.ToList());
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
    }
}

