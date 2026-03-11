using Microsoft.EntityFrameworkCore;
using NurserySystem_HRWebAPI.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace HRWebAPI_Test
{
    public class GenericRepositoryTest
    {
        private TestDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase($"TestDb_{System.Guid.NewGuid()}")
                .Options;

            return new TestDbContext(options);
        }


        [Fact]
        public async Task AddAsync_And_GetById_ShouldWork()
        {
            var context = GetDbContext();
            var repo = new GenericRepository<TestEntity, int>(context);

            var entity = new TestEntity
            {
                Id = 1,
                Name = "Item 1"
            };

            await repo.AddAsync(entity);
            await repo.SaveAsync();

            var result = await repo.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Item 1", result!.Name);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAll()
        {
            var context = GetDbContext();
            var repo = new GenericRepository<TestEntity, int>(context);

            await repo.AddAsync(new TestEntity { Id = 1, Name = "Item 1" });
            await repo.AddAsync(new TestEntity { Id = 2, Name = "Item 2" });
            await repo.SaveAsync();

            var all = await repo.GetAllAsync();

            Assert.Equal(2, all.Count());

        }

        [Fact]
        public async Task FindAllAsync_ShouldFilter()
        {
            var context = GetDbContext();
            var repo = new GenericRepository<TestEntity, int>(context);

            await repo.AddAsync(new TestEntity { Id = 1, Name = "Nisha" });
            await repo.AddAsync(new TestEntity { Id = 2, Name = "shain" });
            await repo.SaveAsync();

            var result = await repo.FindAllAsync(x => x.Name.Equals("shain"));

            Assert.Single(result);
            Assert.Equal("shain",result.First().Name);

        }

        [Fact]
        public async Task Update_ShouldChangeEntity()
        {
            var context = GetDbContext();
            var repo = new GenericRepository<TestEntity, int>(context);

            var entity = new TestEntity { Id = 1, Name ="nisha" };
            await repo.AddAsync(entity);
            await repo.SaveAsync();

            entity.Name = "shain";
            repo.Update(entity);
            await repo.SaveAsync();

            var update = await repo.GetByIdAsync(1);
            Assert.Equal("shain", update!.Name);
        }

        [Fact]
        public async Task Delete_ShouldRemoveEntity()
        {
            var context = GetDbContext();
            var repo = new GenericRepository<TestEntity, int>(context);

            var entity = new TestEntity { Id = 1, Name = "nisha" };
            await repo.AddAsync(entity);
            await repo.SaveAsync();

            repo.Delete(entity);
            repo.SaveAsync();

            var result = await repo.GetByIdAsync(1);
            Assert.Null(result);
        }

    }
}
