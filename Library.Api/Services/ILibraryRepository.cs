using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Api.Entities;

namespace Library.Api.Services
{
    public interface ILibraryRepository
    {

        IEnumerable<Author> GetAuthors();
        Author GetAuthor(Guid authorid);

        IEnumerable<Author> GetAuthor(IEnumerable<Guid> authorids);

        void AddAuthor(Author author);

        void DeleteAuthor(Author author);

        void UpdateAuthor(Author author);
        bool AuthorExist(Guid authorid);

        IEnumerable<Books> GetBooksForAuthor(Guid authorId);
        Books GetBookForAuthor(Guid authorId, Guid bookId);
        void AddBookForAuthor(Guid authorId, Books book);
        void UpdateBookForAuthor(Books book);
        void DeleteBook(Books book);
        bool Save();


    }
}
