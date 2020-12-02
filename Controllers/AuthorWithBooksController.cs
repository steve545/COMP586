using CoreAngCombinedNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CoreAngCombinedNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    /*ControllerBase*/
    public class AuthorWithBooksController : Controller{
        private readonly BookDatabaseContext _context;

        public AuthorWithBooksController(BookDatabaseContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var authors = from a in _context.Authors
                          select a;

            return View(authors.ToList());
        }
        // GET: api/AuthorWithBooks/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<AuthorWithBooksVM>>> GetAuthorWithBooks(int id)
        {
            IQueryable<AuthorWithBooksVM> authorWithBooks = from a in _context.Authors
                                  where a.AuthorId == id
                                  select new AuthorWithBooksVM
                                  {
                                      AuthorName = a.Name,
                                      BookNameList = a.Books.ToList() //a.Books.Select(b => b.Title).ToList()
                                  };


            return View(await authorWithBooks.ToListAsync());
        }
    }
}