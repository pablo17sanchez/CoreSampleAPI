using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Api.Services;
using AutoMapper;
using Library.Api.Models;

namespace Library.Api.Controllers
{
    
    public class BooksController : Controller
    {
        private LibraryRepository _libraryrepository;
      
        public BooksController(LibraryRepository libraryrepository) {


            _libraryrepository = libraryrepository;

        }
        [HttpGet("api/author/{id}/books")]
        public IActionResult GetBookForAuthor(Guid id)
        {
          
            try
            {

        

            if (!_libraryrepository.AuthorExist(id))
            {
                return NotFound();
            }


            var Books = _libraryrepository.GetBooksForAuthor(id);


            var booksforauthors = Mapper.Map<IEnumerable<BookDto>>(Books);

            return Ok(booksforauthors);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "error");
                
            }
        }

    }
}
