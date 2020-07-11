using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookClubLibrary;
using BookClubLibrary.DTO;
using BookClubLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookClubController : ControllerBase
    {
        private readonly IBookClubRepository _repo;
        private readonly IMapper _mapper;

        public BookClubController(IBookClubRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ClubReaderReadDTO>>
            PostReaderAsync(ClubReaderCreateDTO reader)
        {
            var readerModel = _mapper.Map<ClubReader>(reader);
            var existingReader = await _repo.ClubReaderExists(readerModel);
            if (existingReader == null)
            {
                await _repo.CreateReaderAsync(readerModel);
                await _repo.SaveChangesAsync();
                var readerWithBooks = _mapper.Map<ClubReaderReadDTO>(readerModel);
                return Ok(readerWithBooks);
            }
            else
            {
                readerModel = await _repo.GetClubReaderByIdWithBooksAsync(existingReader.Id);
                var readerWithBooks = _mapper.Map<ClubReaderReadDTO>(readerModel);
                return Ok(readerWithBooks);
            }
        }
        [HttpPut]
        [Route("readers")]
        public async Task<ActionResult> PostReaderAsync(ClubReaderUpdateDTO reader)
        {
            var readerModel = _mapper.Map<ClubReader>(reader);
            var bookModel = _mapper.Map<IEnumerable<Book>>(reader.Books);
            await _repo.UpdateClubReaderAsync(readerModel, bookModel);
            await _repo.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("books")]
        public async Task<ActionResult<IEnumerable<BookReadDTO>>> GetBooks()
        {
            var books = await _repo.GetBooksAsync();
            if (books == null || books.Count() == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }
        [HttpGet]
        [Route("readersWithBooks/{id}")]
        public async Task<ActionResult<ClubReaderWithBooksReadDTO>> GetReaderWithBooksById(int id)
        {
            var reader = await _repo.GetClubReaderByIdWithBooksAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ClubReaderWithBooksReadDTO>(reader);
            return Ok(model);
        }
    }
}