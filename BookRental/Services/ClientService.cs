using BookRental.Entities;

namespace BookRental.Services
{
    public interface IClientService
    {
        void Add(Client client);
    }

    public class ClientService : IClientService
    {
        private readonly BookRentalDbContext _dbContext;

        public ClientService(BookRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }
    }
}