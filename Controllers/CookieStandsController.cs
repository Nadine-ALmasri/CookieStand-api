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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace cookie_stand_api.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandsController : ControllerBase
    {
        private readonly CookieDbContext _context;
        private readonly ICookieStand _cookieStandServiescs;
        private readonly IHourlySales _hourlySales;
        public CookieStandsController(CookieDbContext context , ICookieStand cookieStandServiescs, IHourlySales hourlySales)
        {
            _context = context;
            _cookieStandServiescs = cookieStandServiescs;
            _hourlySales = hourlySales;
        }

        // GET: api/CookieStands
        [HttpGet]
        //[Authorize]
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
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<CookieStand>> PostCookieStand(CookiePost cookie)
        {
            var cookiestand = await _cookieStandServiescs.Create(cookie);
            if (cookiestand == null)
            {
                return BadRequest();
            }

            return Ok(cookiestand);
        }
       [Authorize]
        // DELETE: api/CookieStands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookieStand(int id)
        {

            await _cookieStandServiescs.Delete(id);

            return NoContent();
        }

      
    }
}
