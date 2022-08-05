using Microsoft.EntityFrameworkCore;

namespace BookRental.Entities
{
    public class BookRentalDbContext : DbContext

    {
        private string _connectionString =
            "Data Source=.\\BookRental.db;";
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Category)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Published)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(c => c.LastName)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(c => c.ContactNumber)
                .IsRequired();

            modelBuilder.Entity<Rent>()
                .Property(c => c.ClientId)
                .IsRequired();
            modelBuilder.Entity<Rent>()
                .Property(c => c.BookId)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}