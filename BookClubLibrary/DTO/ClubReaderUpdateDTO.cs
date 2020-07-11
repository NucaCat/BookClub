using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookClubLibrary.DTO
{
    public class ClubReaderUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        public string Login { get; set; }
        public ICollection<BookCreateDTO> Books { get; set; }
    }
}
