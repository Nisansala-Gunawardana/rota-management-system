using System.ComponentModel.DataAnnotations;

namespace NurserySystem_HRWebAPI.DTOs
{
    public class EmployeeDTo
    {
        
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Surname")]
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public bool EmpStatus { get; set; } = true;
    }
}
