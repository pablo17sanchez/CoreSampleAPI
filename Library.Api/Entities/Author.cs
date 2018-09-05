using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Entities
{
    public class Author
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]

        public String FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }

        [Required]

        public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public String Genre { get; set; }

        public ICollection<Books> Books { get; set; }
      = new List<Books>();





        public Author() {

            Id = Guid.NewGuid();
            
        }
    }
}
