﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAngCombinedNew.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreAngCombinedNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]                 
    public class AuthorsController : Controller
    {
        private readonly BookDatabaseContext _context;

        public AuthorsController(BookDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authors>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> GetAuthors(int id)
        {
            var authors = await _context.Authors.FindAsync(id);

            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> PutAuthors(int id, Authors authors)
        {
            if (id != authors.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(authors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Authors>> PostAuthors(Authors authors)
        {
            _context.Authors.Add(authors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthors", new { id = authors.AuthorId }, authors);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<ActionResult<Authors>> DeleteAuthors(int id)
        {
            var authors = await _context.Authors.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(authors);
            await _context.SaveChangesAsync();

            return authors;
        }

        private bool AuthorsExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
