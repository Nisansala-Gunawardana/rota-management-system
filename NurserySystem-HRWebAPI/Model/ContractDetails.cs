using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NurserySystem_HRWebAPI.Model
{
    public class ContractDetails:BaseEntity<int>
    {
        [Required]
        public string EmpId { get; set; } = "";
        [Required]
        public string ContractType { get; set; } = string.Empty;
        public int? ContractHours { get; set; }
        public DateTime CStartDate { get; set; }
        public DateTime CEndDate { get; set; }
        public string HourlyRate { get; set; }= string.Empty;
        public string NoOfLeave { get; set; }=string.Empty;
        public Boolean CStatus { get; set; } = true;

        [ForeignKey("EmpId")]
        public Employee Employee { get; set; } = null!;
    }
}
