using System.ComponentModel.DataAnnotations;

namespace NurserySystem_HRWebAPI.Model
{
    public class Employee:BaseEntity<string>
    {

        public string FirstName { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateTime DOB { get; set; }
        public string? Phone { get; set; }=string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Address { get; set; }= string.Empty;
        public bool EmpStatus { get; set; } = true;

        public List<ContractDetails> Contracts { get; set; } = new List<ContractDetails>();
    }
}
