using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using WebDemo.Models;

namespace WebDemo.Api
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBooksRepository _repo = new BooksRepository();


        // GET api/books
        [HttpGet]
        public Task<IEnumerable<Book>> Get()
        {
            return _repo.GetBooks();
        }

        // GET api/books/5
        [HttpGet("{id}", Name = "GetByIdRoute")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _repo.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(book);
        }

        // POST api/books
        public async Task Post(Book newBook)
        {
            try
            {
                var book = await _repo.AddBook(newBook);

                Context.Response.Headers["Location"] = Url.RouteUrl("GetByIdRoute", new { id = book.Id });
                Context.Response.StatusCode = (int)HttpStatusCode.Created;
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                await Response.WriteAsync(ex.Message);
            }
        }

        // PUT api/books/5
        public async Task Put(int id, Book newBook)
        {
            try
            {
                if (newBook.Id != id)
                {
                    throw new ValidationException("Invalid book ID.");
                }
                await _repo.UpdateBook(newBook);
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                await Response.WriteAsync(ex.Message);
            }
        }

        // DELETE api/books/5
        public async Task Delete(int id)
        {
            try
            {
                await _repo.DeleteBook(id);
                Response.StatusCode = (int)HttpStatusCode.NoContent;
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                await Response.WriteAsync(ex.Message);
            }
        }
    }
}
