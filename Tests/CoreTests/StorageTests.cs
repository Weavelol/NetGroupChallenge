using NUnit.Framework;
using Core.Models;
using System;

namespace Tests.CoreTests {

    [TestFixture]
    public class StorageTests {
        [Test]
        public void StorageCreateTest() {
            var storage = new Storage();

            Assert.NotNull(storage);
            Assert.AreEqual(Guid.Empty, storage.Id);
            Assert.AreEqual(string.Empty, storage.Title);
            Assert.AreEqual(null, storage.ParentStorageId);
            Assert.AreEqual(null, storage.ParentStorage);
            Assert.AreEqual(null, storage.NestedStorages);
            Assert.AreEqual(null, storage.NestedItems);
            Assert.AreEqual(string.Empty, storage.OwnerId);
            Assert.AreEqual(string.Empty, storage.StoragePath);
        }
    }
}
