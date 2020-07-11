using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookClubLibrary.DTO
{
    public class ClubReaderCreateDTO
    {
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        [MinLength(1)]
        public string Login { get; set; }
    }
}
