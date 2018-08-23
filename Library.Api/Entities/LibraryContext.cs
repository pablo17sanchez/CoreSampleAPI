using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.Entities
{
    public class LibraryContext: DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options) :base(options) {

           // Database.Migrate();
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
    }
}
