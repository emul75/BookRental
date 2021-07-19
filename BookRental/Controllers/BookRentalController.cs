using System.Collections.Generic;
using BookRental.Entities;
using BookRental.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookRental.Controllers
{
    [Controller]
    [Route("api/book")]
    public class BookRentalController : Controller
    {
        private readonly ILogger<BookRentalController> _logger;
        private readonly IBookRentalService _service;
        private readonly BookRentalDbContext _dbContext;

        public BookRentalController(ILogger<BookRentalController> logger,IBookRentalService service, BookRentalDbContext dbContext)
        {
            _logger = logger;
            _service = service;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<Book> GetById(int id)
        {
            var book = _service.GetById(id);
            return Ok(book);
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _service.GetAll();
            return Ok(books);
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            _service.Add(book);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Book book, int id)
        {
            _service.Update(book, id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }


        [HttpPost("rent")]
        public ActionResult Rent(int id, string name)
        {
            _service.Rent(id, name);
            return Ok();
        }

        [HttpPost("return")]
        public ActionResult Return(int id)
        {
            _service.Return(id);
            return Ok();
        }
    }
}