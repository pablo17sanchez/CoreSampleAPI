using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Api.Entities;

namespace Library.Api.Services
{
    public class LibraryRepository : ILibraryRepository

    {
        private LibraryContext _context;


        public LibraryRepository(LibraryContext context) {

            _context = context;

        }


        public void AddAuthor(Author author)
        {

            author.Id = Guid.NewGuid();

            _context.Authors.Add(author);
            if (author.Books.Any()) {

                foreach (var books in author.Books)
                {
                    books.Id = Guid.NewGuid();

                }
            }

        }

        public void AddBookForAuthor(Guid authorId, Books book)
        {
            var author = GetAuthor(authorId);
            if (author!=null)
            {

                if (book.Id == Guid.Empty) {


                    book.Id = Guid.NewGuid();

                }

                author.Books.Add(book);

            }
        }

        public bool AuthorExist(Guid authorid)
        {
            return _context.Authors.Any(a => a.Id == authorid);

        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);


        }

        public void DeleteBook(Books book)
        {
            _context.Books.Remove(book);

        }

        public Author GetAuthor(Guid authorid)
        {
          return  _context.Authors.FirstOrDefault(a => a.Id == authorid);
        }

        public IEnumerable<Author> GetAuthor(IEnumerable<Guid> authorids)
        {

            return _context.Authors.OrderBy(a => a.FirstName).ThenBy(a => a.LastName);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.OrderBy(a => a.FirstName).ThenBy(a => a.LastName);

        }

        public Books GetBookForAuthor(Guid authorId, Guid bookId)
        {

            return _context.Books.Where(a => a.AuthorId == authorId && a.Id == bookId).FirstOrDefault();




        }

        public IEnumerable<Books> GetBooksForAuthor(Guid authorId)
        {
            return _context.Books.Where(b => b.AuthorId == authorId).OrderBy(b => b.Title).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAuthor(Author author)
        {
          //nom implemented

        }

        public void UpdateBookForAuthor(Books book)
        {
          //no implemented


        }
    }
}
