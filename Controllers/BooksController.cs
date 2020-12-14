using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAngCombinedNew.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CoreAngCombinedNew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly BookDatabaseContext _context;

        public BooksController(BookDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BookDto>> GetBooks(int id)
        {
            Books book = await _context.Books.FindAsync(id);
            Authors author = await _context.Authors.FindAsync(book.AuthorId);
            
            if (book == null)
            {
                return NotFound();
            }

            BookDto bookDto = new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorName = author.Name,
                Price = book.Price
            };
            return bookDto;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutBooks(int id, Books books)
        {
            if (id != books.BookId)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Books>> PostBooks(Books books)
        {
            _context.Books.Add(books);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = books.BookId }, books);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Books>> DeleteBooks(int id)
        {
            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.Books.Remove(books);
            await _context.SaveChangesAsync();

            return books;
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
