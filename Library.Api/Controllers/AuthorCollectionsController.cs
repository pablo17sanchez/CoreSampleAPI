using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Api.Services;
using Library.Api.Models;
using AutoMapper;
using Library.Api.Entities;

namespace Library.Api.Controllers
{

    [Route("api/authorcollections")]
    public class AuthorCollectionsController: Controller
    {
        private ILibraryRepository _libraryrepository;

        public AuthorCollectionsController(ILibraryRepository libraryrepository) {
            _libraryrepository = libraryrepository;

        }

        [HttpPost()]
        public IActionResult CreateAuthorCollection([FromBody] IEnumerable<AuthorForCreationDto> authorforcollection) {


            if (authorforcollection==null)
            {


                return BadRequest();
            }
            var AuthorEntities = Mapper.Map<IEnumerable<Author>>(authorforcollection);

            foreach (var author in AuthorEntities)
            {

                _libraryrepository.AddAuthor(author);

            }

            if (!_libraryrepository.Save())
            {
                return StatusCode(500, "Error al guardar en la base de datos");
            }


            return Ok();
            
        }


        [HttpGet("({ids})")]

        public IActionResult GetAuthorCollection(IEnumerable<Guid> ids) {



        }

    }
}
