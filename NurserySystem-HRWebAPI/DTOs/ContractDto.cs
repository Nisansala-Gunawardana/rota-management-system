using System.ComponentModel.DataAnnotations;

namespace NurserySystem_HRWebAPI.DTOs
{
    public class ContractDto
    {
        public int Id { get; set; }
        [Required, Display(Name = "Employee ID")]
        public string EmpId { get; set; } = "";
        [Required, Display(Name = "Contract Type")]

        public string EmployeName { get; set; } = string.Empty;
        public string ContractType { get; set; } = string.Empty;
        [Display(Name = "Contract Hours")]
        public int? ContractHours { get; set; } 
        [Display(Name = "Contract Start Date")]
        public DateTime CStartDate { get; set; }
        [Display(Name = "Contract End Date")]
        public DateTime CEndDate { get; set; }
        [Display(Name = "Hourly Rate")]
        public string HourlyRate { get; set; } = string.Empty;
        [Display(Name = "No of Leaves")]
        public string NoOfLeave { get; set; } = string.Empty;
        [Display(Name = "Contract Status")]
        public Boolean CStatus { get; set; } = true;
    }
}
