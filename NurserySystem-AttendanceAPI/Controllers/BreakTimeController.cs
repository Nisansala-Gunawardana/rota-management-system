using Microsoft.AspNetCore.Mvc;
using NurserySystem_AttendanceAPI.DTOs;
using NurserySystem_AttendanceAPI.Model;
using NurserySystem_AttendanceAPI.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NurserySystem_AttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakTimeController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BreakTimeController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        // GET: api/<BreakTimeController>
        [HttpGet]
        public async Task<IActionResult> GetAllBreakTimes()
        {
            var breaktimes = await _uow.BreakTimes.GetAllAsync();
            if (breaktimes == null)
            {
                return NotFound("Break Time Not Found");

            }
            return Ok(breaktimes);
        }

        // GET api/<BreakTimeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreakTimeById(int id)
        {
            var breaktime = await _uow.BreakTimes.GetByIdAsync(id);
            if (breaktime == null)
            {
                return NotFound("Break Time Not Found");
            }

            return Ok(breaktime);
        }

        // POST api/<BreakTimeController>
        [HttpPost]
        public async Task<IActionResult> CreateBreakTime([FromBody] BreakTimeDTO breakdto )
        {
            var breaktime = new BreakTimes
            {
                DurationMinutes = breakdto.DurationMinutes,
                IsActive = true
            };

            await _uow.BreakTimes.AddAsync(breaktime);
            await _uow.BreakTimes.SaveAsync();

            return CreatedAtAction(nameof(GetAllBreakTimes), new {id=breaktime.Id},breaktime);
        }

        // PUT api/<BreakTimeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBreakTime(int id, [FromBody] BreakTimeDTO breakDto)
        {
            var breaktime = await _uow.BreakTimes.GetByIdAsync(id);
            if (breaktime == null)
            {
                return BadRequest("Break Time Not Found");
            }
            breaktime.DurationMinutes = breakDto.DurationMinutes;
            breaktime.IsActive = breakDto.IsActive;

            _uow.BreakTimes.Update(breaktime);
            await _uow.BreakTimes.SaveAsync();
            return NoContent();
        }

        // DELETE api/<BreakTimeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreakTime(int id)
        {
            var breaktime = await _uow.BreakTimes.GetByIdAsync(id);
            if (breaktime == null)
            {
                return BadRequest("Break Time Not Found");
            }
            _uow.BreakTimes.Delete(breaktime);
            await _uow.BreakTimes.SaveAsync();
            return NoContent();
        }
    }
}
