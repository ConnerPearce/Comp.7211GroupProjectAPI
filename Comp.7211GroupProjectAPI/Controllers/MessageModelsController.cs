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
    [Route("api/MessageModels")]
    [ApiController]
    public class MessageModelsController : ControllerBase
    {
        private readonly SQLiteContext _context;

        public MessageModelsController(SQLiteContext context)
        {
            _context = context;
        }

        // GET: api/MessageModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageModel>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        // GET: api/MessageModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageModel>> GetMessageModel(int id)
        {
            var messageModel = await _context.Messages.FindAsync(id);

            if (messageModel == null)
            {
                return NotFound();
            }

            return messageModel;
        }

        // PUT: api/MessageModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageModel(int id, MessageModel messageModel)
        {
            if (id != messageModel.id)
            {
                return BadRequest();
            }

            _context.Entry(messageModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageModelExists(id))
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

        // POST: api/MessageModels
        [HttpPost]
        public async Task<ActionResult<MessageModel>> PostMessageModel(MessageModel messageModel)
        {
            _context.Messages.Add(messageModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessageModel), new { id = messageModel.id }, messageModel);
        }

        // DELETE: api/MessageModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageModel>> DeleteMessageModel(int id)
        {
            var messageModel = await _context.Messages.FindAsync(id);
            if (messageModel == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(messageModel);
            await _context.SaveChangesAsync();

            return messageModel;
        }

        private bool MessageModelExists(int id)
        {
            return _context.Messages.Any(e => e.id == id);
        }
    }
}