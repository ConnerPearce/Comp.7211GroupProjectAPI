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
    [Route("api/SettingsModels")]
    [ApiController]
    public class SettingsModelsController : ControllerBase
    {
        private readonly SQLiteContext _context;

        public SettingsModelsController(SQLiteContext context)
        {
            _context = context;
        }

        // GET: api/SettingsModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettingsModel>>> GetSettings()
        {
            return await _context.Settings.ToListAsync();
        }

        // GET: api/SettingsModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SettingsModel>> GetSettingsModel(int id)
        {
            var settingsModel = await _context.Settings.FindAsync(id);

            if (settingsModel == null)
            {
                return NotFound();
            }

            return settingsModel;
        }

        // PUT: api/SettingsModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSettingsModel(int id, SettingsModel settingsModel)
        {
            if (id != settingsModel.id)
            {
                return BadRequest();
            }

            _context.Entry(settingsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingsModelExists(id))
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

        // POST: api/SettingsModels
        [HttpPost]
        public async Task<ActionResult<SettingsModel>> PostSettingsModel(SettingsModel settingsModel)
        {
            _context.Settings.Add(settingsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSettingsModel), new { id = settingsModel.id }, settingsModel);
        }

        // DELETE: api/SettingsModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SettingsModel>> DeleteSettingsModel(int id)
        {
            var settingsModel = await _context.Settings.FindAsync(id);
            if (settingsModel == null)
            {
                return NotFound();
            }

            _context.Settings.Remove(settingsModel);
            await _context.SaveChangesAsync();

            return settingsModel;
        }

        private bool SettingsModelExists(int id)
        {
            return _context.Settings.Any(e => e.id == id);
        }
    }
}