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
            return Ok(book);
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<BookDto>> GetAll()
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

            _service.Add(dto);

            return Ok();
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

            _service.Update(dto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);

            return Ok();
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

            _service.Rent(dto);
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