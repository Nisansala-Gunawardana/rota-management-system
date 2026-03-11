namespace NurserySystem_AttendanceAPI.Model
{
    public class RoomDetails:BaseEntity<int>
    {
        public string RoomCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
