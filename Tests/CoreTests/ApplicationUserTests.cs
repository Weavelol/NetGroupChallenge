using NUnit.Framework;
using Core.Models;
using System;

namespace Tests.CoreTests {
    [TestFixture]
    public class ApplicationUserTests {
        [Test]
        public void UserCreateTest() {
            var user = new ApplicationUser();

            Assert.NotNull(user);
            Assert.AreNotEqual(Guid.Empty, user.Id);
            Assert.AreEqual(null, user.LastLoginDate);
            Assert.AreEqual(null, user.LastLoginDate);
            Assert.AreEqual(null, user.UserName);
            Assert.AreEqual(null, user.NormalizedUserName);
            Assert.AreEqual(null, user.Email);
            Assert.AreEqual(null, user.NormalizedEmail);
            Assert.IsFalse(user.EmailConfirmed);
            Assert.AreEqual(null, user.PhoneNumber);
        }
    }
}
