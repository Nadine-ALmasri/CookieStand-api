using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cookie_stand_api.Data;
using cookie_stand_api.Model;
using cookie_stand_api.Model.Services;
using cookie_stand_api.Model.DTO;
using cookie_stand_api.Model.Interface;

namespace cookie_stand_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandsController : ControllerBase
    {
        private readonly CookieDbContext _context;
        private readonly ICookieStand _cookieStandServiescs;
        public CookieStandsController(CookieDbContext context , ICookieStand cookieStandServiescs)
        {
            _context = context;
            _cookieStandServiescs = cookieStandServiescs;
        }

        // GET: api/CookieStands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookieStand>>> GetCookieStand()
        {
        var cookiestands = await _cookieStandServiescs.GetCookieStand();
            return Ok(cookiestands);
        }

        // GET: api/CookieStands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookieStand>> GetCookieStand(int id)
        {
        var cookieStand = await _cookieStandServiescs.GetCookieStand(id);
            return cookieStand;
        }

        // PUT: api/CookieStands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookieStand(int id, CookieStandDTO cookieStand)
        {
            var updatedCookieStand = await _cookieStandServiescs.Update(cookieStand, id);

            if (updatedCookieStand == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/CookieStands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CookieStand>> PostCookieStand(CookieStandDTO cookieStandDTO)
        {
            var cookiestand = await _cookieStandServiescs.Create(cookieStandDTO);
            if (cookiestand == null)
            {
                return BadRequest();
            }

            return Ok(cookiestand);
        }

        // DELETE: api/CookieStands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookieStand(int id)
        {

            await _cookieStandServiescs.Delete(id);

            return NoContent();
        }

      
    }
}
