using Microsoft.EntityFrameworkCore;

namespace BookRental.Entities
{
    public class BookRentalDbContext : DbContext

    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=BookRentalDb;Trusted_Connection=True;";

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Book>()
                .Property(b => b.Category)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Book>()
                .Property(b => b.Published)
                .IsRequired();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}