using NUnit.Framework;
using Core.Models;
using System;

namespace Tests.CoreTests {
    [TestFixture]
    public class StatisticsTests {
        
        [Test]
        public void StatisticsCreateTest() {
            var statistics = new Statistics();

            Assert.NotNull(statistics);
            Assert.AreEqual(0, statistics.StoragesAmount);
            Assert.AreEqual(0, statistics.ItemsAmount);
            Assert.AreEqual(0, statistics.MaxItemsInStorage);
            Assert.AreEqual(DateTime.Now.ToShortDateString(), 
                    statistics.RegistrationDate.ToShortDateString());
            Assert.AreEqual(DateTime.Now.ToShortDateString(), 
                statistics.LastLoginDate.ToShortDateString());
        }
    }
}
