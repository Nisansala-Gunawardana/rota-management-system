using Microsoft.EntityFrameworkCore;
using NurserySystem_HRWebAPI.Data;
using NurserySystem_HRWebAPI.Model;
using NurserySystem_HRWebAPI.Repository;
using NurserySystem_HRWebAPI.Repository.Implementation;

namespace NurserySystem_HRWebAPI.UnitofWork.UoWImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext _context;
        public IGenericRepository<Employee, string> Employees { get; }
        public IGenericRepository<ContractDetails, int> Contracts { get; }

        public UnitOfWork(HRDbContext context)
        {
            _context = context;
            Employees = new GenericRepository<Employee, string>(_context);
            Contracts = new GenericRepository<ContractDetails,int>(_context);

        }
      
        public async Task SaveAsync()
        {
             await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
