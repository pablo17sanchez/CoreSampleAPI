using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Models
{
    public class AuthorForCreationDto
    {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public String Genre { get; set; }

        public ICollection<BooksForCreationDto> books { get; set; } = new List<BooksForCreationDto>();
    }
}
