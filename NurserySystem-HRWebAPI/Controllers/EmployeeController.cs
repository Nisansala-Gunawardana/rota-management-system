using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using NurserySystem_HRWebAPI.DTOs;
using NurserySystem_HRWebAPI.Model;
using NurserySystem_HRWebAPI.UnitofWork;
using System.Text;

namespace NurserySystem_HRWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            if (employees == null)
            {
                return NotFound("Employees Not Found");
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(string id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not found!");
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTo empdto)
        {
            var newEmpId = await GenerateEmpIdAsync();

            var employee = new Employee
            {
                Id = newEmpId,
                FirstName = empdto.FirstName,
                Surname = empdto.Surname,
                Address = empdto.Address,
                DOB = empdto.DOB,
                Email = empdto.Email,
                Phone = empdto.Phone,
                EmpStatus = empdto.EmpStatus
            };

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id,EmployeeDTo empdto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if(employee == null)
            {
                return NotFound("Employee Not Found");
            }
            else
            {
                employee.FirstName = empdto.FirstName;
                employee.Surname = empdto.Surname;
                employee.Address = empdto.Address;
                employee.DOB = empdto.DOB;
                employee.Email = empdto.Email;
                employee.Phone = empdto.Phone;
                employee.EmpStatus = empdto.EmpStatus;

                _unitOfWork.Employees.Update(employee);
                await _unitOfWork.Employees.SaveAsync();

                return NoContent();

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var emp = await _unitOfWork.Employees.GetByIdAsync(id);

            if(emp == null)
            {
                return NotFound("Employee not found");
            }
            else
            {
                _unitOfWork.Employees.Delete(emp);
                await _unitOfWork.Employees.SaveAsync();
                return NoContent();
            }

        }

        private async Task<string> GenerateEmpIdAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            var lastemp = employees.OrderByDescending(x => x.Id).FirstOrDefault();

            int lastnumber = 0;
            var empid = "";

            if(lastemp == null)
            {
                empid = "EMP001";
            }
            else
            {
                var numpart = lastemp.Id.Substring(3);
                lastnumber = int.Parse(numpart);
            }

            empid = "EMP" + (lastnumber + 1).ToString("D3");
            return empid;

        }
    }
}
