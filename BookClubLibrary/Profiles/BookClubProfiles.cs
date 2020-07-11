using AutoMapper;
using BookClubLibrary.DTO;
using BookClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookClubLibrary.Profiles
{
    public class BookClubProfiles : Profile
    {
        public BookClubProfiles()
        {
            CreateMap<Book, BookReadDTO>();
            CreateMap<ClubReader, ClubReaderReadDTO>();
            //CreateMap<ClubReader, ClubReaderWithBooksReadDTO>();
            CreateMap<ClubReader, ClubReaderWithBooksReadDTO>()
                .ForMember(d => d.Books, o => o.MapFrom(s => s.ClubReaderBooks.Select(c => c.Book).ToArray()));
            CreateMap<ClubReaderBook, ClubReaderBookReadDTO>();

            CreateMap<ClubReaderCreateDTO, ClubReader>();
            CreateMap<ClubReaderUpdateDTO, ClubReader>();
            CreateMap<BookCreateDTO, Book>();
        }
    }
}
