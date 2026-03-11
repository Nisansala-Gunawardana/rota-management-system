namespace NurserySystem_AttendanceAPI.Model
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; } = default;
    }
}
