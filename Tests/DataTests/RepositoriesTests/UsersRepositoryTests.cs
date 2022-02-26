using NUnit.Framework;
using Moq;
using Data;
using Data.Repositories;
using Data.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using System.Data.Entity.Infrastructure;

namespace Tests.DataTests.RepositoriesTests {
    [TestFixture]
    public class UsersRepositoryTests {
        private Mock<ApplicationDbContext> fakeDbContext;
        private IUsersRepository usersRepository;

        [SetUp]
        public void Setup() {
            var data = new List<ApplicationUser>
            {
                new ApplicationUser { Id = Guid.NewGuid().ToString(), Email = "FirstEmail" },
                new ApplicationUser { Id = Guid.NewGuid().ToString(), Email = "SecondEmail"},
                new ApplicationUser { Id = Guid.NewGuid().ToString(), Email = "Test" },
            }.AsQueryable();

            var fakeUsers = new Mock<DbSet<ApplicationUser>>();

            fakeUsers.As<IDbAsyncEnumerable<ApplicationUser>>()
                 .Setup(m => m.GetAsyncEnumerator())
                 .Returns(new TestDbAsyncEnumerator<ApplicationUser>(data.GetEnumerator()));

            fakeUsers.As<IQueryable<ApplicationUser>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<ApplicationUser>(data.Provider));

            fakeUsers.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(data.Expression);
            fakeUsers.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(data.ElementType);
            fakeUsers.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var options = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
            var someOptions = Options.Create(new OperationalStoreOptions());

            fakeDbContext = new Mock<ApplicationDbContext>(options, someOptions);
            fakeDbContext.Setup(x => x.Users).Returns(fakeUsers.Object);

            usersRepository = new UsersRepository(fakeDbContext.Object);
        }

        [Test]
        public async Task GetAllUsersTest() {
            var result = await usersRepository.GetAllAsync();
            
            Assert.NotNull(result);
            Assert.AreEqual(3, result.ToList().Count);
        }

    }
}
