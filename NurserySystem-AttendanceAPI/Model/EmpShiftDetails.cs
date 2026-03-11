namespace NurserySystem_AttendanceAPI.Model
{
    public class EmpShiftDetails:BaseEntity<int>
    {
        public string EMPId { get; set; } = "";
        public int WorkingDay { get; set; } //  1=monday,5=friday
        public string WorkShift { get; set; } = string.Empty;

        public bool ShiftStatus { get; set; } = true;

    }
}
