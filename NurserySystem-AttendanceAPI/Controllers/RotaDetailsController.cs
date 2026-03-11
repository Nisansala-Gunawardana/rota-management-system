using Microsoft.AspNetCore.Mvc;
using NurserySystem_AttendanceAPI.DTOs;
using NurserySystem_AttendanceAPI.Model;
using NurserySystem_AttendanceAPI.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NurserySystem_AttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RotaDetailsController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        // GET: api/<RotaDetailsController>
        [HttpGet]
        public async Task<IActionResult> GetAllRotaDetails()
        {
            var rotadtls = await _uow.RotaDetails.GetAllAsync();
            if (rotadtls == null)
            {
                return NotFound("Rota Details Not Found");
            }

            return Ok(rotadtls);
        }

        // GET api/<RotaDetailsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRotaDetailsById(int id)
        {
            var rotadtls = await _uow.RotaDetails.GetByIdAsync(id);
            if(rotadtls == null)
            {
                return NotFound("Rota Details Not Found");
            }
            return Ok(rotadtls);
        }

        // POST api/<RotaDetailsController>
        [HttpPost]
        public async Task<IActionResult> CreateRota([FromBody] RotaDetailsDTO rotadto)
        {
            var rota = new RotaDetails
            {
                EmpId = rotadto.EmpId,
                WeekSdate = rotadto.WeekSdate,
                WorkDate = rotadto.WorkDate,
                WorkShift = rotadto.WorkShift,
                RoomId = rotadto.RoomId,
                BreakTimeId = rotadto.BreakTimeId

            };

            await _uow.RotaDetails.AddAsync(rota);
            await _uow.RotaDetails.SaveAsync();
            return CreatedAtAction(nameof(GetAllRotaDetails), new { id = rota.Id }, rota);
        }

        // PUT api/<RotaDetailsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRotaDetails(int id, [FromBody] RotaDetailsDTO rotadto)
        {
            var rotadtls = await _uow.RotaDetails.GetByIdAsync(id);
            if (rotadtls == null)
            {
                return NotFound("Rota Details Not Found");
            }
            else
            {
                rotadtls.WeekSdate = rotadto.WeekSdate;
                rotadtls.EmpId = rotadto.EmpId;
                rotadtls.WorkDate = rotadto.WorkDate;
                rotadtls.RoomId= rotadto.RoomId;
                rotadtls.WorkShift = rotadto.WorkShift;
                rotadtls.BreakTimeId = rotadto.BreakTimeId;

                _uow.RotaDetails.Update(rotadtls);
                await _uow.RotaDetails.SaveAsync();
                return NoContent();
            }
        }

        // DELETE api/<RotaDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRota(int id)
        {
            var rota = await _uow.RotaDetails.GetByIdAsync(id);
            if(rota == null)
            {
                return NotFound("Rota Not Found");
            }
            else
            {
                _uow.RotaDetails.Delete(rota);
                await _uow.RotaDetails.SaveAsync();
                return NoContent();
            }
        }
    }
}
