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
    // Route is api/Users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Comp7211GroupProjectAPI20191115092109_dbContext _context;

        public UsersController(Comp7211GroupProjectAPI20191115092109_dbContext context)
        {
            _context = context;
        }



        // GET: api/Users/5
        [HttpGet("userID={id}&Password={pwrd}")]
        public async Task<ActionResult<Users>> GetUsers(string id, string pwrd)
        {
            var users = await _context.Users.FirstAsync(e => e.Uid == id && e.Pword == pwrd);

            if (users == null)
            {
                return NotFound(null);
            }

            return users;
        }


        // Used to update (Easier, less complicated and easier to specify individual changes)
        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUsers(Users users)
        {
            var user = await _context.Users.Where(e => e.Id == users.Id).FirstAsync();
            if (user != null)
            {
                user.Nickname = users.Nickname;
                user.Pword = users.Pword;

                await _context.SaveChangesAsync();

                return Ok();
            }
            else
                return NotFound();
        }
    


    }
}
