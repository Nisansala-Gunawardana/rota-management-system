namespace NurserySystem_AttendanceAPI.Model
{
    public class EmpAbsentDetails:BaseEntity<int>
    {
        public string EmpId { get; set; }=string.Empty;
        public DateTime AbsentDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
