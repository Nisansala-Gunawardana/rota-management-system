using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NurserySystem_AttendanceAPI.Data;
using NurserySystem_AttendanceAPI.Model;
using NurserySystem_AttendanceAPI.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendenceAPI_TestProject
{
    public class GenericRepositoryTest : IDisposable
    {
        private readonly AttendanceDbContext _context;
        private readonly IDbContextTransaction _tx;
        private readonly GenericRepository<EmpShiftDetails, int> _repo;

        public GenericRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AttendanceDbContext>()
                .UseSqlServer("Data Source=DESKTOP-2HARTGO\\MSSQLSERVER22;Initial Catalog=AttWebAPIdb;User ID=sa;Password=glitter123;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;

            _context = new AttendanceDbContext(options);
            _tx = _context.Database.BeginTransaction();
            _repo = new GenericRepository<EmpShiftDetails, int>(_context);


        }

        [Fact]
        public async Task AddAsyncshiftDtls_ThenGetById_ShouldReturnEntity()
        {
            var empatt = new EmpShiftDetails
            {
                EMPId = "EMP001",
                WorkingDay = 2,
                WorkShift = "7.30am - 6.00 pm",
                ShiftStatus = true
            };

            await _repo.AddAsync(empatt);
            await _repo.SaveAsync();

            var empshift = await _repo.GetByIdAsync(empatt.Id);

            Assert.NotNull(empshift);
            Assert.Equal("EMP001", empshift!.EMPId);

        }

        [Fact]
        public async Task GetAll_ShouldReturnAllRecords()
        {
            await _repo.AddAsync( new EmpShiftDetails{ EMPId = "EMP001",  WorkingDay = 2, WorkShift = "7.30am - 6.30pm", ShiftStatus = true });
            await _repo.AddAsync(new EmpShiftDetails { EMPId = "EMP001", WorkingDay = 5, WorkShift = "7.30am - 6.30pm", ShiftStatus = true });
            await _repo.SaveAsync();

            var results = await _repo.FindAllAsync(a=>a.EMPId=="EMP001");
            Assert.Equal(2, results.Count());

        }

        [Fact]
        public async Task Update_ShouldReturnChangedRecord()
        {
           var empshift = new EmpShiftDetails { EMPId = "EMP001", WorkingDay = 2, WorkShift = "7.30-6.30", ShiftStatus = true };
            await _repo.AddAsync(empshift);
            await _repo.SaveAsync();

            empshift.ShiftStatus = false;
             _repo.Update(empshift);
            await _repo.SaveAsync();

            var res = await _repo.GetByIdAsync(empshift.Id);
            Assert.NotNull(res);
            Assert.False(res!.ShiftStatus);
        }
        public void Dispose()
        {
            _tx.Rollback();
            _tx.Dispose();
            _context.Dispose();
        }
    }
}
