using System;
using System.Collections.Generic;
using System.Text;

namespace BookClubLibrary.Models
{
    public class ClubReaderBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ClubReaderId { get; set; }
        public ClubReader ClubReader { get; set; }
    }
}
