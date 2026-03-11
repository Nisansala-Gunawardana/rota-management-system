using Microsoft.EntityFrameworkCore;
using NurserySystem_HRWebAPI.Data;
using NurserySystem_HRWebAPI.Model;
using NurserySystem_HRWebAPI.UnitofWork.UoWImplementation;

namespace HRWebAPI_Test
{
    public class UnitOfWorkTests
    {
        private HRDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<HRDbContext>()
                .UseInMemoryDatabase(databaseName: $"HRDb_{System.Guid.NewGuid()}")
                .Options;

            return new HRDbContext(options);
        }

        [Fact]
        public async Task Employees_AddAndSave_ShouldPersist()
        {
            // arrange
            var context = GetInMemoryDbContext();
            var uow = new UnitOfWork(context);

            var employee = new Employee
            {
                Id = "EMP001",
                FirstName = "Shain",
                Surname = "Wisidagama",
                Address = "wewerwer",
                // DOB="1982/01/23",
                Email = "shain@gmail.com",
                Phone = "07380214167",
                EmpStatus = true
            };

            // Act

            await uow.Employees.AddAsync(employee );
            await uow.SaveAsync();

            //Assert
            var saved = await context.Employees.FindAsync("EMP001");
            Assert.NotNull( saved );
            Assert.Equal("Shain", saved.FirstName);

        }

        [Fact]
        public async Task Contracts_AddAndSave_ShouldPersist()
        {
            //arrange
            var context = GetInMemoryDbContext();
            var uow = new UnitOfWork(context);

            var contract = new ContractDetails
            {
               // Id = 1,
                EmpId = "EMP001",
                ContractType = "FullTime",
                CStartDate = DateTime.Parse("01/01/2023"),
                CEndDate = DateTime.Parse("01/01/2027"),
                ContractHours = 40,
                HourlyRate = "12.50",
                NoOfLeave ="28",
                CStatus=true

            };

            //Act
            await uow.Contracts.AddAsync(contract);
            await uow.Contracts.SaveAsync();

            //Assert
            var saved = await context.ContractDetails.FindAsync(1);
            Assert.NotNull(saved);
            Assert.Equal("EMP001", saved.EmpId);

        }

        [Fact]
        public void Dispose_ShouldDisposeDbContext()
        {
            //arrange
            var context = GetInMemoryDbContext();
            var uow = new UnitOfWork(context);

            //act 
            uow.Dispose();

            //assert
            Assert.Throws<ObjectDisposedException>(() => context.Employees.AnyAsync().GetAwaiter().GetResult());

        }
    }
}