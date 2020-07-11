using BookClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClubLibrary.DTO
{
    public class ClubReaderWithBooksReadDTO
    {
        public ClubReaderWithBooksReadDTO()
        {
            Books = new HashSet<BookReadDTO>();
        }
        public string Login { get; set; }
        public virtual ICollection<BookReadDTO> Books { get; set; }
    }
}
