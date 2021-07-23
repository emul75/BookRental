using System;
using System.Collections.Generic;
using System.Linq;
using BookRental.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookRental
{
    public class BookSeeder
    {
        private readonly BookRentalDbContext _dbContext;

        public BookSeeder(BookRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (!_dbContext.Database.CanConnect()) return;
            if (_dbContext.Books.Any()) return;
            
            var books = GetBooks();
            _dbContext.Books.AddRange(books);
            _dbContext.SaveChanges();
        }

        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>
            {
                new()
                {
                    Title = "Master Thaddeus",
                    Author = "Adam Mickiewicz",
                    Category = "Epic poem",
                    Published = new DateTime(1834, 06, 28)
                },
                new()
                {
                    Title = "The Knights of the Cross",
                    Author = "Henryk Sienkiewicz",
                    Category = "Historical Novel",
                    Published = new DateTime(1900, 01, 1)
                },
                new()
                {
                    Title = "The Old Man and the Sea",
                    Author = "Ernest Hemingway",
                    Category = "Literary Fiction",
                    Published = new DateTime(1952, 05, 7)
                }
            };
            return books;
        }
    }
}