using NUnit.Framework;
using Core.Models;
using System;

namespace Tests.CoreTests {
    [TestFixture]
    public class ItemImageTests {
        [Test]
        public void ImageCreateTest() {
            var image = new ItemImage();

            Assert.NotNull(image);
            Assert.AreEqual(Guid.Empty, image.Id);
            Assert.AreEqual(string.Empty, image.Title);
            Assert.AreEqual(Array.Empty<byte>(), image.ImageData);
        }
    }
}
