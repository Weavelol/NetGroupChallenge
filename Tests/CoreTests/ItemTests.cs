using NUnit.Framework;
using Core.Models;
using System;

namespace Tests.CoreTests {
    [TestFixture]
    public class ItemTests {
        [Test]
        public void ItemCreateTest() {
            var item = new Item();

            Assert.NotNull(item);
            Assert.AreEqual(Guid.Empty, item.Id);
            Assert.AreEqual(string.Empty, item.Title);
            Assert.AreEqual(Guid.Empty, item.StorageId);
            Assert.AreEqual(null, item.ParentStorage);
            Assert.AreEqual(Guid.Empty, item.ImageId);
            Assert.AreEqual(null, item.Image);
            Assert.AreEqual(null, item.SerialNumber);
            Assert.AreEqual(null, item.Classification);
            Assert.AreEqual(null, item.ItemOwner);
            Assert.AreEqual(null, item.Weight);
            Assert.AreEqual(null, item.Length);
            Assert.AreEqual(null, item.Width);
            Assert.AreEqual(null, item.Height);
        }
    }
}
