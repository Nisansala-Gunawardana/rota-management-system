using Microsoft.AspNetCore.Mvc;
using NurserySystem_AttendanceAPI.DTOs;
using NurserySystem_AttendanceAPI.Model;
using NurserySystem_AttendanceAPI.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NurserySystem_AttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAbsentController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public EmpAbsentController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        // GET: api/<EmpAbsentController>
        [HttpGet]
        public async Task<IActionResult> GetAllEmpAbsents()
        {
            var empabsent = await _uow.AbsentDetails.GetAllAsync();
            if (empabsent == null)
            {
                return NotFound("Employee Absent Detail Not Found");
            }
            return Ok(empabsent);
        }

        // GET api/<EmpAbsentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbsentById(int id)
        {
            var empabsent = await _uow.AbsentDetails.GetByIdAsync(id);
            if (empabsent == null)
            {
                return NotFound("Employee Absent Detail Not Found");
            }
            return Ok(empabsent);
        }

        // POST api/<EmpAbsentController>
        [HttpPost]
        public async Task<IActionResult> CreateEmpAbsent([FromBody] EmpAbsentDTO absentdto)
        {
            var absentdtls = new EmpAbsentDetails
            {
                EmpId = absentdto.EmpId,
                AbsentDate = absentdto.AbsentDate,
                Reason = absentdto.Reason,
                CreatedAt = DateTime.Now
            };

            await _uow.AbsentDetails.AddAsync(absentdtls);
            await _uow.AbsentDetails.SaveAsync();
            return CreatedAtAction(nameof(GetAllEmpAbsents), new { id = absentdtls.Id }, absentdtls);
        }

        // PUT api/<EmpAbsentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbsentDtls(int id, [FromBody] EmpAbsentDTO absentdto)
        {
            var absent = await _uow.AbsentDetails.GetByIdAsync(id);
            if (absent == null)
            {
                return NotFound("Employee Absent Details Not Found");
            }
            else
            {
                _uow.AbsentDetails.Update(absent);
                await _uow.AbsentDetails.SaveAsync();
                return NoContent();
            }
        }

        // DELETE api/<EmpAbsentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsentDtls(int id)
        {
            var absent = await _uow.AbsentDetails.GetByIdAsync(id);
            if(absent == null)
            {
                return NotFound("Employee Absent Details Not Found");
            }
            else
            {
                _uow.AbsentDetails.Delete(absent);
                await _uow.AbsentDetails.SaveAsync();
                return NoContent();
            }
        }
    }
}
