using Microsoft.AspNetCore.Mvc;
using NurserySystem_AttendanceAPI.DTOs;
using NurserySystem_AttendanceAPI.Model;
using NurserySystem_AttendanceAPI.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NurserySystem_AttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpShiftDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public EmpShiftDetailsController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        // GET: api/<EmpShiftDetailsController>
        [HttpGet]
        public async Task<IActionResult> GetAllEmpShifts()
        {
            var empshifts = await _uow.ShiftDetails.GetAllAsync();
            if (empshifts == null)
            {
                return NotFound("Employee Shifts not found");
            }

            return Ok(empshifts);
        }

        // GET api/<EmpShiftDetailsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpShiftById(int id)
        {
           var empshift = await _uow.ShiftDetails.GetByIdAsync(id);
            if (empshift == null)
            {
                return NotFound("Employee Shift Not Found");
            }

            return Ok(empshift);
        }

        // POST api/<EmpShiftDetailsController>
        [HttpPost]
        public async Task<IActionResult> CreateEmpShift([FromBody] EmpShiftDtlsDTO empshiftdto)
        {
            var empshift = new EmpShiftDetails
            {
                EMPId = empshiftdto.EMPId,
                WorkingDay = empshiftdto.WorkingDay,
                WorkShift = empshiftdto.WorkShift,
                ShiftStatus = empshiftdto.ShiftStatus
            };

            await _uow.ShiftDetails.AddAsync(empshift);
            await _uow.ShiftDetails.SaveAsync();
            return CreatedAtAction(nameof(GetAllEmpShifts), new {Id=empshift.Id},empshift);
        }

        // PUT api/<EmpShiftDetailsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpShifts(int id, [FromBody] EmpShiftDtlsDTO empshiftdto)
        {
            var empshift = await _uow.ShiftDetails.GetByIdAsync(id);
            if (empshift == null)
            {
                return NotFound("Employee shift Not Found");
            }
            else
            {
                empshift.EMPId = empshiftdto.EMPId;
                empshift.WorkShift = empshiftdto.WorkShift;
                empshift.WorkingDay = empshiftdto.WorkingDay;
                empshift.ShiftStatus = empshiftdto.ShiftStatus;

                _uow.ShiftDetails.Update(empshift);
                await _uow.ShiftDetails.SaveAsync();
                return NoContent();
            }
        }

        // DELETE api/<EmpShiftDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpShift(int id)
        {
            var empshift = await _uow.ShiftDetails.GetByIdAsync(id);
            if (empshift == null)
            {
                return NotFound("Employee Shift Not Found");
            }
            else
            {
                _uow.ShiftDetails.Delete(empshift);
                await _uow.ShiftDetails.SaveAsync();
                return NoContent();
            }
        }
    }
}
