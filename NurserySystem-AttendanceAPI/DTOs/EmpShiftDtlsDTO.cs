using System.ComponentModel.DataAnnotations;

namespace NurserySystem_AttendanceAPI.DTOs
{
    public class EmpShiftDtlsDTO
    {
        [Required,Display(Name ="Employee ID")]
        public string EMPId { get; set; } = "";
        [Display(Name ="Working Day")]
        public int WorkingDay { get; set; } //  1=monday,5=friday
        [Display(Name = "Work Shift")]
        public string WorkShift { get; set; } = string.Empty;
        [Display(Name = "Shift Status")]
        public bool ShiftStatus { get; set; } = true;

    }
}
