using System;
using System.Collections.Generic;
using System.Linq;
using BookRental.Entities;

namespace BookRental.Services
{
    public interface IBookRentalService
    {
        Book GetById(int id);
        IEnumerable<Book> GetAll();
        int Add(Book book);
        void Update(Book updateBook, int id);
        void Delete(int id);
        void Rent(int id, string name);
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

        public int Add(Book book)
        {
            _dbContext.Add(book);
            _dbContext.SaveChanges();
            return book.Id;
        }

        public void Update(Book updateBook, int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }

            book = updateBook;
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

        public void Rent(int id, string name)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }

            if (book.RentalStatus is true)
            {
                throw new Exception("Book already rented");
            }

            book.RentalStatus = true;
            book.ClientName = name;
            book.Rented = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public void Return(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }

            if (book.RentalStatus is false)
            {
                throw new Exception("Book is not rented");
            }

            book.RentalStatus = false;
            book.Returned = DateTime.Now;
            _dbContext.SaveChanges();
        }
    }
}