using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comp._7211GroupProjectAPI.Models;

namespace Comp._7211GroupProjectAPI.Controllers
{
    // Route is api/Posts
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly Comp7211GroupProjectAPI20191115092109_dbContext _context;

        public PostsController(Comp7211GroupProjectAPI20191115092109_dbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult<Posts>> PostPosts(Posts posts)
        {
            _context.Posts.Add(posts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = posts.Id }, posts);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Posts>> DeletePosts(int id)
        {
            var posts = await _context.Posts.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();

            return posts;
        }
    }
}
