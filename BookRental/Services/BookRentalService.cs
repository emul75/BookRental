using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BookRental.Entities;
using BookRental.Exceptions;
using BookRental.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Services
{
    public interface IBookRentalService
    {
        Book GetById(int id);
        IEnumerable<BookDto> GetAll();
      void Add(AddBookDto dto);
        void Update(UpdatedBookDto dto);
        void Delete(int id);
        void Rent(RentOrReturnBookDto dto);
        void Return(int id);
        bool IsRented(int id);
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
                throw  new NotFoundException("Book not found.");
            }
            return book;
        }

        public IEnumerable<BookDto> GetAll()
        {
            var books = _dbContext.Books.ToList();
            var booksDto = new List<BookDto>();

            foreach (Book book in books)
            {
                var rents = _dbContext.Rents.Where(r => r.BookId == book.Id).Include(r => r.Client);
                var rent = new Rent();
                if (rents.Any())
                {
                    rent = rents.OrderBy(r => r.Rented).Last();

                    if (rent.Returned is null)
                    {
                        booksDto.Add(new BookDto()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = book.Author,
                            Category = book.Category,
                            Published = book.Published,
                            FirstName = rent.Client.FirstName,
                            LastName = rent.Client.LastName,
                            ContactNumber = rent.Client.ContactNumber,
                            Rented = rent.Rented,
                        });
                    }
                    else
                    {
                        booksDto.Add(new BookDto()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = book.Author,
                            Category = book.Category,
                            Published = book.Published,
                            FirstName = rent.Client.FirstName,
                            LastName = rent.Client.LastName,
                            ContactNumber = rent.Client.ContactNumber,
                            Rented = rent.Rented,
                            Returned = rent.Returned
                        });
                    }
                }
                else
                {
                    booksDto.Add(new BookDto()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Category = book.Category,
                        Published = book.Published,
                    });
                }
            }

            return booksDto;
        }

        public void Add(AddBookDto dto)
        {
            var newBook = new Book()
            {
                Title = dto.Title,
                Author = dto.Author,
                Category = dto.Category,
            };
            try
            {
                newBook.Published = DateTime.ParseExact(dto.Published, "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateFormatException("Invalid date format.");
            }


            _dbContext.Books.Add(newBook);
            _dbContext.SaveChanges();
        }

        public void Update(UpdatedBookDto dto)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == dto.Id);
            if (book is null)
            {
                throw new NotFoundException("Book not found.");
            }

            if (dto.Title is not null)
                book.Title = dto.Title;
            if (dto.Author is not null)
                book.Author = dto.Author;
            if (dto.Category is not null)
                book.Category = dto.Category;
            if (dto.Published is not null)
            {
                try
                {
                    book.Published = DateTime.ParseExact(dto.Published, "d/M/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    throw new InvalidDateFormatException("Invalid date format.");
                }
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new NotFoundException("Book not found.");
            }

            if (_dbContext.Rents.Any(r => r.Book.Id == id && r.Returned == null))
            {
                throw new BookUnavailableException("Book is currently rented.");
            }

            _dbContext.Remove(book);
            _dbContext.SaveChanges();
        }

        public void Rent(RentOrReturnBookDto dto)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.ContactNumber == dto.ContactNumber);
            if (client is null)
            {
                throw new NotFoundException("Client with this number not found.");
            }

            var rent = new Rent()
            {
                Book = _dbContext.Books.First(b => b.Id == dto.Id),
                Client = client,
                Rented = DateTime.Now,
                Returned = null
            };
            _dbContext.Rents.Add(rent);
            _dbContext.SaveChanges();
        }

        public void Return(int id)
        {
            var rent = _dbContext.Rents.First(r => r.BookId == id && r.Returned == null);
            rent.Returned = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public bool IsRented(int id)
        {
            return _dbContext.Rents.Any(r => r.Book.Id == id && r.Returned == null);
        }
    }
}