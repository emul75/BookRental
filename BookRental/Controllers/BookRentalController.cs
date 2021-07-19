using System.Collections.Generic;
using BookRental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookRental.Controllers
{
    [Controller]
    [Route("api/book")]
    public class BookRentalController : Controller
    {
        private readonly ILogger<BookRentalController> _logger;
        private readonly BookRentalDbContext _dbContext;

        public BookRentalController(ILogger<BookRentalController> logger, BookRentalDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        //add, delete, edit, rent, return

        [HttpGet]
        public ActionResult<Book> GetById(int id)
        {
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult Update()
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return Ok();
        }


        [HttpPost("rent")]
        public ActionResult Rent()
        {
            return Ok();
        }

        [HttpPost("return")]
        public ActionResult Return()
        {
            return Ok();
        }
    }
}