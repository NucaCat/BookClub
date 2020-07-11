using BookClubLibrary.DTO;
using BookClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClubLibrary.Data
{
    public class BookClubRepository : IBookClubRepository
    {
        private readonly BookClubDbContext _context;

        public BookClubRepository(BookClubDbContext context)
        {
            _context = context;
        }

        public async Task<ClubReader> CreateReaderAsync(ClubReader clubReader)
        {
            await _context.ClubReaders.AddAsync(clubReader);
            return clubReader;
        }

        public async Task<ClubReader> ClubReaderExists(ClubReader reader)
        {
            return await _context
                        .ClubReaders
                        .FirstOrDefaultAsync(x => x.Login == reader.Login);
        }

        /*public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }*/

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<ClubReader> GetClubReaderByIdWithBooksAsync(int id)
        {
            return await _context.ClubReaders
                    .Include(x => x.ClubReaderBooks)
                    .ThenInclude(x => x.Book)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }
        /*
        public async Task<IEnumerable<ClubReader>> GetClubReadersWithBooksAsync()
        {
            return await _context.ClubReaders
                    .Include(x => x.ClubReaderBooks)
                    .ThenInclude(x => x.Book)
                    .ToListAsync();
        }*/
        /*
        public async Task<ClubReader> GetClubReaderByIdAsync(int id)
        {
            return await _context.ClubReaders.FindAsync(id);
        }*/
        /*
        public async Task<IEnumerable<ClubReader>> GetClubReadersAsync()
        {
            return await _context.ClubReaders.ToListAsync();
        }*/

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateClubReaderAsync(ClubReader reader, IEnumerable<Book> books)
        {
            var readerModel = await _context.ClubReaders
                                        .Include(x => x.ClubReaderBooks)
                                        .FirstOrDefaultAsync(x => x.Id == reader.Id);
            readerModel.ClubReaderBooks = new List<ClubReaderBook>();
            foreach (var x in books)
            {
                var book = await _context.Books.FindAsync(x.Id);
                readerModel.ClubReaderBooks.Add
                (
                    new ClubReaderBook { Book = book, ClubReader = reader }
                );
            }
        }
    }
}
