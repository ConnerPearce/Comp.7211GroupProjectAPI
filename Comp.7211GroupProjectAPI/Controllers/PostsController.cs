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
        public async Task<ActionResult<string>> PostPosts(Posts posts)
        {
            try
            {
                var temp = await _context.Posts.Where(e => e.Id == posts.Id).FirstAsync();
                if (temp != null)
                {
                    temp.Post = posts.Post;
                    temp.UpVote = posts.UpVote;
                    temp.DownVote = posts.DownVote;
                }
                else
                    _context.Posts.Add(posts);

                await _context.SaveChangesAsync();

                return Ok("Posted Successfully");
            }
            catch 
            {
                return BadRequest("Unable to post, Try again later");
            }

        }


        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletePosts(int id)
        {
            var posts = await _context.Posts.FindAsync(id);
            if (posts == null)
            {
                return NotFound("Unable to delete");
            }

            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();

            return Ok("Deleted post");
        }
    }
}
