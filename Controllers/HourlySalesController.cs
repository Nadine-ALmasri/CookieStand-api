using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cookie_stand_api.Data;
using cookie_stand_api.Model;
using cookie_stand_api.Model.Interface;
using cookie_stand_api.Model.DTO;

namespace cookie_stand_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourlySalesController : ControllerBase
    {
        private readonly IHourlySales _hourlySales;

        public HourlySalesController( IHourlySales hourlySales)
        {
          
            _hourlySales = hourlySales;
        }

        // GET:GET: api/HourlySales/CookieStand/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HourlySales>>> GetHourlySales()
        {
         
          var hourly= await _hourlySales.GetAllHourlySales();
            return Ok(hourly);
        }

        // GET: api/HourlySales/5
        [HttpGet("CookieStand/{cookieStandId}")]
        public async Task<ActionResult<List<HourlySales>>> GetHourlySalesByCookieStandId(int cookieStandId)
        {


        
            var hourlySales = await _hourlySales.GetHourlySalesByCookieStandId(cookieStandId);

            if (hourlySales == null)
            {
                return NotFound();
            }

            return hourlySales;
        }

        // PUT: api/HourlySales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHourlySales(int id, HourlySalesDTO hourlySales)
        {
            var updatedHourlySales = await _hourlySales.UpdateHourlySales(id, hourlySales);

            if (updatedHourlySales == null)
            {
                return NotFound(); // Handle the case where the hourly sales record is not found.
            }

            return Ok(updatedHourlySales);
        }

        // POST: api/HourlySales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HourlySales>> PostHourlySales(HourlySalesDTO hourlySalesDTO)
        {
            var added = _hourlySales.CreateHourlySales(hourlySalesDTO);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok(added);
        }

        // DELETE: api/HourlySales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHourlySales(int id)
        {
            _hourlySales.DeleteHourlySales(id);

            return NoContent();
        }

        [HttpGet("/api/hourlysales/{hourlySalesId}")]
        public async Task<IActionResult> GetHourlySalesById(int hourlySalesId)
        {
            var hourlySales = await _hourlySales.GetHourlySalesById(hourlySalesId);

            if (hourlySales == null)
            {
                return NotFound(); // Handle the case where the hourly sales record is not found.
            }

            return Ok(hourlySales);
        }
    }
}
