using NurserySystem_AttendanceAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace NurserySystem_AttendanceAPI.DTOs
{
    public class RotaDetailsDTO
    {
        [Required, Display(Name = "Employee ID")]
        public string EmpId { get; set; } = "";
        [Display(Name = "Week Commence")]
        public DateTime WeekSdate { get; set; }
        [Display(Name = "Work Date")]
        public DateTime WorkDate { get; set; }
        [Display(Name = "Shift")]
        public string WorkShift { get; set; } = string.Empty;
        [Display(Name = "Location")]
        public int RoomId { get; set; }
      
        public float WorkingHours { get; set; }
        public int BreakTimeId { get; set; }
        public DateTime FinalizedDate { get; set; }

       
    }
}
