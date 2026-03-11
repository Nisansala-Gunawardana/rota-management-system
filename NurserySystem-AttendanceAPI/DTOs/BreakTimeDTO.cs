namespace NurserySystem_AttendanceAPI.DTOs
{
    public class BreakTimeDTO
    {
        public int DurationMinutes { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
