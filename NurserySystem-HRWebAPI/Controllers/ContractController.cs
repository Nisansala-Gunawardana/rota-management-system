using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurserySystem_HRWebAPI.DTOs;
using NurserySystem_HRWebAPI.Model;
using NurserySystem_HRWebAPI.UnitofWork;
using System.Diagnostics.Contracts;
using static System.Net.Mime.MediaTypeNames;

namespace NurserySystem_HRWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IUnitOfWork _unit;

        public ContractController(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContracts()
        {
            var contracts= await _unit.Contracts.GetAllAsync(c=>c.Employee);
            var result = contracts.Select(c => new ContractDto
            {
                Id =c.Id,
                EmpId = c.EmpId,
                EmployeName = c.Employee.FirstName + " " + c.Employee.Surname,
                ContractType = c.ContractType,
                ContractHours = c.ContractHours,
                CStartDate = c.CStartDate,
                CEndDate = c.CEndDate,
                HourlyRate = c.HourlyRate,
                NoOfLeave = c.NoOfLeave,
                CStatus = c.CStatus
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractById(int id)
        {
            var cont = await _unit.Contracts.GetByIdAsync(id);
            if(cont == null)
            {
                return NotFound("Employee Contracts Not Found");
            }
            return Ok(cont);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] ContractDto cdto)
        {
            var emp = await _unit.Employees.GetByIdAsync(cdto.EmpId);
            if(emp== null)
            {
                return NotFound("Employee Id not Found");
            }
            else if (emp.EmpStatus == true)
            {
                return BadRequest("Employee has another active contract");
            }

            var contract = new ContractDetails
            {
                EmpId = cdto.EmpId,
                ContractType = cdto.ContractType,
                CStartDate = cdto.CStartDate,
                CEndDate = cdto.CEndDate,
                ContractHours = cdto.ContractHours,
                HourlyRate = cdto.HourlyRate,
                NoOfLeave = cdto.NoOfLeave,
                CStatus = true
            };

            await _unit.Contracts.AddAsync(contract);
            await _unit.Contracts.SaveAsync();
            return CreatedAtAction(nameof(GetContractById), new { id = contract.Id }, contract);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, [FromBody] ContractDto cdto)
        {
            var cont = await _unit.Contracts.GetByIdAsync(id);
            if(cont == null)
            {
                return NotFound("Employee Contract Not Found");
            }

            cont.EmpId = cdto.EmpId;
            cont.ContractType = cdto.ContractType;
            cont.CStartDate = cdto.CStartDate;
            cont.CEndDate = cdto.CEndDate;
            cont.ContractHours = cdto.ContractHours;
            cont.HourlyRate = cdto.HourlyRate;
            cont.NoOfLeave = cdto.NoOfLeave;
            cont.CStatus = cdto.CStatus;

            _unit.Contracts.Update(cont);
            await _unit.Contracts.SaveAsync();
            return NoContent();
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            var cont = await _unit.Contracts.GetByIdAsync(id);

            if(cont == null)
            {
                return NotFound("Employee Contract Not Found");
            }

            _unit.Contracts.Delete(cont);
            await _unit.Contracts.SaveAsync();
            return NoContent();
        }
    }
}
