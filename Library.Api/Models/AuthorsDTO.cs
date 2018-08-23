using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Models
{
    public class AuthorsDTO
    {
        public Guid id { get; set; }

        public String Name { get; set; }

        public int Age { get; set; }

        public String Genre { get; set; }

    }
}
