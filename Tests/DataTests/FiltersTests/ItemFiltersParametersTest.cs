using NUnit.Framework;
using Data.FilterParameters;

namespace Tests.DataTests.FiltersTests {
    [TestFixture]
    public class ItemFiltersParametersTest {
        [Test]
        public void ItemFiltersParametersCreateTest() { 
            var filterParameters = new ItemFiltersParameters();
            Assert.NotNull(filterParameters);
            Assert.IsNull(filterParameters.Title);
            Assert.IsNull(filterParameters.StorageTitle);
            Assert.IsNull(filterParameters.SerialNumber);
            Assert.IsNull(filterParameters.Classification);
            Assert.IsNull(filterParameters.ItemOwner);
            Assert.IsNull(filterParameters.Weight);
            Assert.IsNull(filterParameters.Length);
            Assert.IsNull(filterParameters.Width);
            Assert.IsNull(filterParameters.Height);
        }
    }
}
