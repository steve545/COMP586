using CoreAngCombinedNew.Models;
using CoreAngCombinedNew.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngCombinedNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsWithBooksController : ControllerBase{
        private readonly BookDatabaseContext _context;

        public AuthorsWithBooksController(BookDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<AuthorWithBooksVM>>> GetAuthorWithBooks(int id)
        {
            IQueryable<AuthorWithBooksVM> authorWithBooks = from a in _context.Authors
                                  where a.AuthorId == id
                                  select new AuthorWithBooksVM
                                  {
                                      AuthorName = a.Name,
                                      BookNameList = a.Books.Select(b => b.Title).ToList()
                                  };

            return await authorWithBooks.ToListAsync();
        }
    }
}
