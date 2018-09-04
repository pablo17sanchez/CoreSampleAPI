using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Api.Services;
using AutoMapper;
using Library.Api.Models;
using Library.Api.Entities;

namespace Library.Api.Controllers
{
    [Route("api/author/{id}/books")]
    public class BooksController : Controller
    {
        private ILibraryRepository _libraryrepository;
      
        public BooksController(ILibraryRepository libraryrepository) {


            _libraryrepository = libraryrepository;

        }
        [HttpGet("api/author/{authorid}/books",Name = "GetBookForAuthor")]
        public IActionResult GetBookForAuthor(Guid authorid)
        {
          
            try
            {

        

            if (!_libraryrepository.AuthorExist(authorid))
            {
                return NotFound();
            }


            var Books = _libraryrepository.GetBooksForAuthor(authorid);


            var booksforauthors = Mapper.Map<IEnumerable<BookDto>>(Books);

            return Ok(booksforauthors);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "error");
                
            }
        }

        [HttpPost()]
        public IActionResult CreateBooksForAuthors(Guid id,[FromBody] BooksForCreationDto books)
        {
            if (books==null)
            {
                return BadRequest();
            }

            if (!_libraryrepository.AuthorExist(id))
            {
                return NotFound();

            }

            var bookentity = Mapper.Map<Books>(books);

            _libraryrepository.AddBookForAuthor(id, bookentity);

            if (!_libraryrepository.Save())
            {
                return StatusCode(500, "Error al guardar en la base de datos");

            }

            var bookss = Mapper.Map<BookDto>(bookentity);

            return CreatedAtRoute("GetBookForAuthor", new { authorid = bookss.Id }, books);
        }

    }
}
