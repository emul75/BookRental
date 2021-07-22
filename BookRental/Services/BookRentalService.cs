using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BookRental.Entities;
using BookRental.Models;

namespace BookRental.Services
{
    public interface IBookRentalService
    {
        Book GetById(int id);
        IEnumerable<Book> GetAll();
        void Add(BookDto dto);
        void Update(UpdatedBookDto dto);
        void Delete(int id);
        void Rent(int bookId, int clienId);
        void Return(int id);
    }

    public class BookRentalService : IBookRentalService
    {
        private readonly BookRentalDbContext _dbContext;

        public BookRentalService(BookRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Book GetById(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }

            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            var books = _dbContext.Books.ToList();
            return books;
        }

        public void Add(BookDto dto)
        {
            var newBook = new Book()
            {
                Title = dto.Title,
                Author = dto.Author,
                Category = dto.Category,
                Published = DateTime.ParseExact(dto.Published, "d/M/yyyy", CultureInfo.InvariantCulture)
            };
            _dbContext.Books.Add(newBook);
            _dbContext.SaveChanges();
        }

        public void Update(UpdatedBookDto dto)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == dto.Id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }
            
            if (dto.Title is not null)
                book.Title = dto.Title;
            if (dto.Author is not null)
                book.Author = dto.Author;
            if (dto.Category is not null)
                book.Category = dto.Category;
            if (dto.Published is not null)
            {
                book.Published = DateTime.ParseExact(dto.Published, "d/M/yyyy", CultureInfo.InvariantCulture);

            }
            
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }

            _dbContext.Remove(book);
            _dbContext.SaveChanges();
        }

        public void Rent(int bookId, int clienId)
        {
            
        }

        public void Return(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }




            _dbContext.SaveChanges();
        }

        public bool IsRented(int id)
        {
            _dbContext.Rents.Any(r=>r.Book.Id == id && r.)
        }
    }
}