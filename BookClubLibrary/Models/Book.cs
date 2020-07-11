using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookClubLibrary.Models
{
    public class Book
    {
        public Book()
        {
            ClubReaderBooks = new HashSet<ClubReaderBook>();
        }
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        public string BookName { get; set; }
        public virtual ICollection<ClubReaderBook> ClubReaderBooks { get; set; }
    }
}
