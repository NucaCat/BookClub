using BookClubLibrary.DTO;
using BookClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookClubLibrary
{
    public interface IBookClubRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        //Task<Book> GetBookByIdAsync(int id);
        //Task<IEnumerable<ClubReader>> GetClubReadersAsync();
        //Task<ClubReader> GetClubReaderByIdAsync(int id);
        Task<ClubReader> ClubReaderExists(ClubReader reader);
        Task<ClubReader> CreateReaderAsync(ClubReader clubReader);
        Task<ClubReader> GetClubReaderByIdWithBooksAsync(int id);
        //Task<IEnumerable<ClubReader>> GetClubReadersWithBooksAsync();
        Task UpdateClubReaderAsync(ClubReader reader, IEnumerable<Book> books);
        Task<bool> SaveChangesAsync();
    }
}
