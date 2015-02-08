using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public interface IBooksRepository : IDisposable
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> AddBook(Book newBook);
        Task<Book> UpdateBook(Book newBook);
        Task DeleteBook(int id);
    }
}