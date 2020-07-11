using BookClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClubLibrary
{
    public class BookClubDbContext : DbContext
    {
        public BookClubDbContext(DbContextOptions<BookClubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<ClubReader> ClubReaders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClubReaderBook>()
                .HasKey(cb => new { cb.BookId, cb.ClubReaderId });
            modelBuilder.Entity<ClubReaderBook>()
                .HasOne(cb => cb.Book)
                .WithMany(b => b.ClubReaderBooks)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<ClubReaderBook>()
                .HasOne(cb => cb.ClubReader)
                .WithMany(c => c.ClubReaderBooks)
                .HasForeignKey(c => c.ClubReaderId);
            Seed(modelBuilder);
        }
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    BookName = "Преступление и наказание"
                },
                new Book
                {
                    Id = 2,
                    BookName = "Мастер и Маргарита"
                },
                new Book
                {
                    Id = 3,
                    BookName = "Война и Мир"
                },
                new Book
                {
                    Id = 4,
                    BookName = "Дубровский"
                },
                new Book
                {
                    Id = 5,
                    BookName = "Анна Каренина"
                }
            );
        }
    }
}
