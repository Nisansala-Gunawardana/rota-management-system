namespace NurserySystem_AttendanceAPI.Model
{
    public class RotaDetails :BaseEntity<int>
    {
        public string EmpId { get; set; } = "";
        public DateTime WeekSdate { get; set; }
        public DateTime WorkDate { get; set; }
        public string WorkShift { get; set; } = string.Empty;
        public int RoomId { get; set; } 
        public float WorkingHours { get; set; }
        public int BreakTimeId { get; set; } 
        public DateTime FinalizedDate { get; set; }

        public RoomDetails RoomDetails { get; set; }= new RoomDetails();
        public BreakTimes BreakTimes { get; set; }=new BreakTimes();
    }   
}
