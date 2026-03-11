namespace NurserySystem_AttendanceAPI.Model
{
    public class BreakTimes:BaseEntity<int>
    {
        public int DurationMinutes { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
