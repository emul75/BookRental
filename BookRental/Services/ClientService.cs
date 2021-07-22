using System;
using System.Linq;
using BookRental.Entities;
using BookRental.Models;

namespace BookRental.Services
{
    public interface IClientService
    {
        bool Add(AddClientDto dto);
    }

    public class ClientService : IClientService
    {
        private readonly BookRentalDbContext _dbContext;

        public ClientService(BookRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(AddClientDto dto)
        {
            if (_dbContext.Clients.Any(c => c.ContactNumber == dto.ContactNumber))
            {
                return false;
            }

            var newClient = new Client()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ContactNumber = dto.ContactNumber
            };
            
            _dbContext.Clients.Add(newClient);
            _dbContext.SaveChanges();
            return true;
        }
    }
}