using NUnit.Framework;
using Moq;
using System;
using Services.Services;
using Data.Interfaces;
using AutoMapper;

namespace Tests.ServicesTests {
    [TestFixture]
    public class StoragesServiceTests {
        private StoragesService storagesService;

        [SetUp]
        public void Setup() {
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<IStoragesRepository> storagesRepositoryMock = new Mock<IStoragesRepository>();


            storagesService = new StoragesService(storagesRepositoryMock.Object, mapperMock.Object);
        }

        [Test]
        public void GetAllAsyncTest() {
            Assert.Inconclusive();
        }

        [Test]
        public void GetByIdAsyncTest() {
            Assert.Inconclusive();
        }

        [Test]
        public void DeleteAsyncTest() {
            Assert.Inconclusive();
        }

        [Test]
        public void CreateAsyncTest() {
            Assert.Inconclusive();
        }
    }
}
