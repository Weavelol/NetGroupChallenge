using NUnit.Framework;
using CoreServices.Services;
using Core.Models;
using Moq;
using System.Collections.Generic;
using System;

namespace Tests.CoreServicesTests {
    [TestFixture]
    public class StatisticsCoreServiceTests {
        private StatisticsCoreService statisticsCoreService;
        private ApplicationUser testUser;
        private List<Storage> storages;

        [SetUp]
        public void SetUp() {
            statisticsCoreService = new StatisticsCoreService();

            testUser = new ApplicationUser {
                RegistrationDate = DateTime.Parse("10/10/2020"),
                LastLoginDate = DateTime.Now.AddDays(-1)
            };

            var testItem1 = new Item();
            var testStorage1 = new Storage {
                NestedItems = new List<Item> { testItem1 }
            };

            var testStorage2 = new Storage {
                Id = Guid.NewGuid(),
            };

            var testItem2 = new Item();

            var testStorage3 = new Storage {
                NestedItems = new List<Item> { testItem2 },
                ParentStorage = testStorage2,
                ParentStorageId = testStorage2.Id
            };

            testStorage2.NestedStorages = new List<Storage> { testStorage3 };

            storages = new List<Storage> {
                testStorage1,
                testStorage2,
                testStorage3
            };
        }

        [Test]
        public void GetStatisticsTest() {
            var statisticsResult = statisticsCoreService.AnalyzeStorages(storages, testUser);


            Assert.NotNull(statisticsResult);
            Assert.AreEqual(3, statisticsResult.StoragesAmount);
            Assert.AreEqual(2, statisticsResult.ItemsAmount);
            Assert.AreEqual(1, statisticsResult.MaxItemsInStorage);
            Assert.AreEqual(DateTime.Parse("10/10/2020").ToShortDateString(),
                statisticsResult.RegistrationDate.ToShortDateString());
            Assert.AreEqual(DateTime.Now.AddDays(-1).ToShortDateString(),
                statisticsResult.LastLoginDate.ToShortDateString());
        }

        [Test]
        public void GetStatisticsWithInvalidDataTest() {
            Assert.Throws<NullReferenceException>(() => statisticsCoreService.AnalyzeStorages(null, null));
            Assert.Throws<NullReferenceException>(() => statisticsCoreService.AnalyzeStorages(storages, null));
            Assert.Throws<NullReferenceException>(() => statisticsCoreService.AnalyzeStorages(null, testUser));
        }
    }
}
