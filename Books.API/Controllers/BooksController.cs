using Books.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _booksRepository;

        public BooksController(IBookRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _booksRepository.GetBooksAsync();
            return Ok(bookEntities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetBook(Guid id)
        {
            var bookEntity = await _booksRepository.GetBookAsync(id);
            if (bookEntity == null) return NotFound();
            return Ok(bookEntity);
        }
    }
}
