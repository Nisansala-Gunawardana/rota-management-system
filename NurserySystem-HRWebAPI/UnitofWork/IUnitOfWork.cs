using NurserySystem_HRWebAPI.Model;
using NurserySystem_HRWebAPI.Repository;

namespace NurserySystem_HRWebAPI.UnitofWork
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Employee,String> Employees { get; }
        IGenericRepository<ContractDetails,int> Contracts { get; }
        Task SaveAsync();
    }
}
