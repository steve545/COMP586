using CoreAngCombinedNew.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CoreAngCombinedNew.Models;

namespace CoreAngCombinedNew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class AuthorWithBooksController : ControllerBase{
        private readonly BookDatabaseContext _context;

        public AuthorWithBooksController(BookDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AuthorWithBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<AuthorWithBooksVM>>> GetAuthorWithBooks(int id)
        {
            IQueryable<AuthorWithBooksVM> authorWithBooks = from a in _context.Authors
                                  where a.AuthorId == id
                                  select new AuthorWithBooksVM
                                  {
                                      AuthorName = a.Name,
                                      BookNameList = a.Books.Select(b=>b.Title).ToList()
                                  };


            return await authorWithBooks.ToListAsync();
        }


    }
}