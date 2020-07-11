using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookClubLibrary.DTO
{
    public class BookCreateDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
