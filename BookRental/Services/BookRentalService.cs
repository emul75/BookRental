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
        void Add(BookDto book);
        void Update(Book updatedBook, int id);
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

        public void Add(BookDto book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Category = book.Category,
                Published = DateTime.ParseExact(book.DatePublished, "d/M/yyyy", CultureInfo.InvariantCulture)
            };
            _dbContext.Books.Add(newBook);
            _dbContext.SaveChanges();
        }

        public void Update(Book updatedBook, int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }

            book = updatedBook;
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
    }
}