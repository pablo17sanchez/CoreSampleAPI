using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Api.Entities;
using Library.Api.Services;
using Library.Api.Models;
using AutoMapper;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController: Controller
    {
        private ILibraryRepository _libraryrepository;

   

        public AuthorController (ILibraryRepository libraryrepository)
        {

            _libraryrepository = libraryrepository;

        }

        [HttpGet("/api/authors")]
        public IActionResult GetAuthors() {

            var authors= _libraryrepository.GetAuthors();



            var listautorhs = Mapper.Map<IEnumerable<AuthorsDTO>>(authors);

            return new JsonResult(listautorhs);

        }

        [HttpGet("/api/authors/{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            try
            {

               

            if (!_libraryrepository.AuthorExist(id))
                {
                  //  throw new Exception("as");

                    return NotFound();

            }
            var author = _libraryrepository.GetAuthor(id);

            var elautor = Mapper.Map<AuthorsDTO>(author);


            return Ok(elautor);

        }
            catch (Exception ex )
            {

                return StatusCode(500, "Error interno del servidor");

            }



}

    }
}
