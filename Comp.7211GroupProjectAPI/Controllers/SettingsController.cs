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
    // Route is api/Settings
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly Comp7211GroupProjectAPI20191115092109_dbContext _context;

        public SettingsController(Comp7211GroupProjectAPI20191115092109_dbContext context)
        {
            _context = context;
        }

        // GET: api/Settings/userID=5
        [HttpGet("userId={id}")]
        public async Task<ActionResult<Settings>> GetSettingsByUser(int id)
        {
            var settings = await _context.Settings.Where(e => e.Uid == id).FirstOrDefaultAsync();

            if (settings == null)
            {
                return NotFound();
            }

            return settings;
        }

        // Used to update (Easier, less complicated and easier to specify individual changes)
        // POST: api/Settings
        [HttpPost]
        public async Task<ActionResult> PostSettings(Settings settings)
        {
            var currentSettings = await _context.Settings.Where(e => e.Id == settings.Id).FirstAsync();
            if (currentSettings != null)
            {
                currentSettings.AppTheme = settings.AppTheme;

                await _context.SaveChangesAsync();

                return Ok();
            }
            else
                return NotFound();
        }


    }
}
