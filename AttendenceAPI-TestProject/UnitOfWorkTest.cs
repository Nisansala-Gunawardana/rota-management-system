using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NurserySystem_AttendanceAPI.Data;
using NurserySystem_AttendanceAPI.UnitOfWork.UOWImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendenceAPI_TestProject
{
    public class UnitOfWorkTest : IDisposable
    {
        private readonly AttendanceDbContext _con;
        private readonly UnitOfWork _uow;
        private readonly IDbContextTransaction _tx;

        public UnitOfWorkTest()
        {
            var options = new DbContextOptionsBuilder<AttendanceDbContext>()
                .UseSqlServer("Server=DESKTOP-2HARTGO\\\\MSSQLSERVER22;Database=AttWebAPIdb;User ID=sa;Password=glitter123;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .Options;

            _con = new AttendanceDbContext(options);
            _tx = _con.Database.BeginTransaction();
            _uow = new UnitOfWork(_con);
        }
        public void Dispose()
        {
            _tx.Rollback();
            _tx.Dispose();
            _con.Dispose();
        }
    }
}
