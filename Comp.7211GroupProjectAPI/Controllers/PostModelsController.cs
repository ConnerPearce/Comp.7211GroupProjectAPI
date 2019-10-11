using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comp._7211GroupProjectAPI;
using Comp._7211GroupProjectAPI.Models;

namespace Comp._7211GroupProjectAPI.Controllers
{
    [Route("api/PostModels")]
    [ApiController]
    public class PostModelsController : ControllerBase
    {
        private readonly SQLiteContext _context;

        public PostModelsController(SQLiteContext context)
        {
            _context = context;
        }

        // GET: api/PostModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostModel>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/PostModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> GetPostModel(int id)
        {
            var postModel = await _context.Posts.FindAsync(id);

            if (postModel == null)
            {
                return NotFound();
            }

            return postModel;
        }

        // PUT: api/PostModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostModel(int id, PostModel postModel)
        {
            if (id != postModel.id)
            {
                return BadRequest();
            }

            _context.Entry(postModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostModelExists(id))
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

        // POST: api/PostModels
        [HttpPost]
        public async Task<ActionResult<PostModel>> PostPostModel(PostModel postModel)
        {
            _context.Posts.Add(postModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostModel), new { id = postModel.id }, postModel);
        }

        // DELETE: api/PostModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostModel>> DeletePostModel(int id)
        {
            var postModel = await _context.Posts.FindAsync(id);
            if (postModel == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(postModel);
            await _context.SaveChangesAsync();

            return postModel;
        }

        private bool PostModelExists(int id)
        {
            return _context.Posts.Any(e => e.id == id);
        }
    }
}