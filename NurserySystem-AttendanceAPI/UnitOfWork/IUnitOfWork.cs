using NurserySystem_AttendanceAPI.Model;
using NurserySystem_AttendanceAPI.Repository;

namespace NurserySystem_AttendanceAPI.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<EmpShiftDetails,int> ShiftDetails { get; }
        IGenericRepository<EmpAbsentDetails,int> AbsentDetails { get; }
        IGenericRepository<RotaDetails,int> RotaDetails { get; }
        IGenericRepository<RoomDetails,int> RoomDetails { get; }
        IGenericRepository<BreakTimes, int> BreakTimes { get; }
        
    }
}
