using NurserySystem_AttendanceAPI.Data;
using NurserySystem_AttendanceAPI.Model;
using NurserySystem_AttendanceAPI.Repository;
using NurserySystem_AttendanceAPI.Repository.Implementation;

namespace NurserySystem_AttendanceAPI.UnitOfWork.UOWImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AttendanceDbContext _context;

        public IGenericRepository<EmpShiftDetails, int> ShiftDetails { get; }

        public IGenericRepository<EmpAbsentDetails, int> AbsentDetails { get; }

        public IGenericRepository<RotaDetails, int> RotaDetails { get; }

        public IGenericRepository<RoomDetails, int> RoomDetails { get; }
        public IGenericRepository<BreakTimes,int> BreakTimes { get; }

        public UnitOfWork(AttendanceDbContext context)
        {
            _context = context;
            ShiftDetails = new GenericRepository<EmpShiftDetails, int>(_context);
            AbsentDetails = new GenericRepository<EmpAbsentDetails, int>(_context);
            RotaDetails = new GenericRepository<RotaDetails, int>(_context);
            RoomDetails = new GenericRepository<RoomDetails, int>(_context);
            BreakTimes = new GenericRepository<BreakTimes, int>(_context);

        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
