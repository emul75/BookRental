﻿using System.Collections.Generic;
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

        public BookRentalController(ILogger<BookRentalController> logger,IBookRentalService service)
        {
            _logger = logger;
            _service = service;
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
            return PartialView("_BookList", books);
        }

        [HttpGet("add")]
        public ActionResult Add()
        {
            return PartialView("_AddBook");
        }
        
        [HttpPost("add")]
        public ActionResult Add(BookDto dto)
        {
            _service.Add(dto);
            return Ok();
        }

        [HttpGet("Update")]
        public ActionResult Update(int id)
        {
            var book = _service.GetById(id);
            return PartialView("_UpdateBook", book);
        }
        
        
        [HttpPost("Update")]
        public ActionResult Update(UpdatedBookDto dto)
        {
            _service.Update(dto);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }


        [HttpPost("rent")]
        public ActionResult Rent(int bookId, int clienId)
        {
            _service.Rent(bookId, clienId);
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