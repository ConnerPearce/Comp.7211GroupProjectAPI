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
    //Route is api/Messages
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly Comp7211GroupProjectAPI20191115092109_dbContext _context;

        public MessagesController(Comp7211GroupProjectAPI20191115092109_dbContext context)
        {
            _context = context;
        }


        // GET: api/Messages/userID=27033991
        [HttpGet("userID={user}")]
        public async Task<ActionResult<IEnumerable<Messages>>> GetMessagesByUser(int user)
        {
            var userMessages = await _context.Messages.Where(e => e.ReceiverId == user || e.SenderId == user).ToListAsync();
            if (userMessages != null)
                return Ok(userMessages);
            else
                return NotFound();
            
        }
     
        // POST: api/Messages
        [HttpPost]
        public async Task<ActionResult<string>> PostMessages(Messages messages)
        { 
            try
            {
                _context.Messages.Add(messages);
                await _context.SaveChangesAsync();
                return Ok("Message Sent");
            }
            catch
            {
                return BadRequest("Message unable to be sent, Try again later");
            }
        }
    }
}
