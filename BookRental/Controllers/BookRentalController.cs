using System.Collections.Generic;
using BookRental.Entities;
using BookRental.Models;
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

        public BookRentalController(ILogger<BookRentalController> logger, IBookRentalService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _service.GetById(id);
            if (book is null)
            {
                return BadRequest("Book not found");
            }

            return Ok(book);
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _service.GetAll();
            return PartialView("_BookList", books);
        }

        [HttpGet("add")]
        public ActionResult Add()
        {
            return PartialView("_AddBook");
        }

        [HttpPost("add")]
        public ActionResult Add(AddBookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = _service.Add(dto);

            return result ? Ok() : BadRequest("Invalid date format");
        }

        [HttpGet("update/{id:int}")]
        public ActionResult Update(int id)
        {
            var book = _service.GetById(id);
            return PartialView("_UpdateBook", book);
        }
        
        [HttpPost("update")]
        public ActionResult Update(UpdatedBookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = _service.Update(dto);

            return result ? Ok() : BadRequest("Invalid date format");
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            bool result = _service.Delete(id);

            return result ? Ok() : BadRequest("Book could not be found or is currently rented.");
        }

        [HttpGet("rentorreturn")]
        public ActionResult RentOrReturn(int id)
        {
            var book = _service.GetById(id);

            return PartialView(_service.IsRented(id) ? "_ReturnBook" : "_RentBook", book);
        }

        [HttpPost("rent")]
        public ActionResult Rent(RentOrReturnBookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = _service.Rent(dto);
            return result ? Ok() : BadRequest("Client with this number could not be found.");
        }
        
        [HttpPost("return")]
        public ActionResult Return(int id)
        {
            _service.Return(id);
            return Ok();
        }
    }
}