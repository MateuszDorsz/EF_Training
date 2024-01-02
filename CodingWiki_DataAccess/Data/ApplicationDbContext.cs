using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }
        public DbSet<Fluent_Book> Book_fluent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);

            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Book>().HasKey(u => u.BookId);
            modelBuilder.Entity<Fluent_Book>().Ignore(u => u.PriceRange);


            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Location = "Chicago", Name = "Pub 1"},
                new Publisher { Publisher_Id = 2, Location = "New York", Name = "Pub 2"},
                new Publisher { Publisher_Id = 3, Location = "Hawaii", Name = "Pub 3"}
                );
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider without Duty", ISBN = "123B12", Price = 10.99m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Fortune of time", ISBN = "12123B12", Price = 11.99m, Publisher_Id = 1 }
                );

            var bookList = new Book[]
            {
                 new Book { BookId = 3, Title = "Fake Sunday", ISBN = "77652", Price = 20.99m, Publisher_Id = 1},
                 new Book { BookId = 4, Title = "Cookie Jar", ISBN = "CC12B12", Price = 25.99m, Publisher_Id = 2},
                 new Book { BookId = 5, Title = "Cloudy Forest", ISBN = "90392B33", Price = 40.99m, Publisher_Id = 3},
            };
            modelBuilder.Entity<Book>().HasData(bookList);
        }
    }
}
