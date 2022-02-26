using NUnit.Framework;
using System.Linq.Expressions;
using Data.FilterParameters;
using Core.Models;
using Data.Filters;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Tests.DataTests.FiltersTests {
    [TestFixture]
    public class ItemFilterTest {
        List<Item> testingList;

        [SetUp]
        public void Setup() {
            testingList = new List<Item> {
                new Item { 
                    Title = "TestTitle",
                    ParentStorage = new Storage {
                        Title = "TestStorageTitle"
                    },
                    SerialNumber = "TestSerialNumber",
                    Classification = "TestClassification",
                    ItemOwner = "TestItemOwner",
                    Weight = 10,
                    Length = 20,
                    Width = 40,
                    Height = 50
                },
                new Item {
                    Title = "testing2",
                    ParentStorage = new Storage {
                        Title = "TestStorage2"
                    },
                    ItemOwner = "TestItemOwner",
                    Length = 20,
                },
                new Item {
                    Title = "testing3",
                    ParentStorage = new Storage {
                        Title = "TestStorage3"
                    },
                    SerialNumber = "TestSerialNumber",
                    Weight = 10,
                    Height = 50
                }
            };

        }

        [Test]
        public void GetFilteringExpressionWithFullDataTest() {
            var filter = new ItemFiltersParameters {
                Title = "TestTitle",
                StorageTitle = "TestStorageTitle",
                SerialNumber = "TestSerialNumber",
                Classification = "TestClassification",
                ItemOwner = "TestItemOwner",
                Weight = 10,
                Length = 20,
                Width = 40,
                Height = 50,
            };

            var resultExpression = ItemFilter.GetFilteringExpression(filter);
            Assert.NotNull(resultExpression);

            var resultValues = testingList.AsQueryable().Where(resultExpression).ToList();

            Assert.NotNull(resultValues);
            Assert.AreEqual(1, resultValues.Count);
        }

        [Test]
        public void GetFilteringExpressionWithPartialDataTest() {
            var filter = new ItemFiltersParameters {
                Title = "testing"
            };

            var resultExpression = ItemFilter.GetFilteringExpression(filter);
            Assert.NotNull(resultExpression);

            var resultValues = testingList.AsQueryable().Where(resultExpression).ToList();

            Assert.NotNull (resultValues);
            Assert.AreEqual(2, resultValues.Count);
        }

        [Test]
        public void GetFilteringExpressionWithPartialDataTest2() {
            var filter = new ItemFiltersParameters {
                StorageTitle = "TestStorage",
                Weight = 10
            };

            var resultExpression = ItemFilter.GetFilteringExpression(filter);
            Assert.NotNull(resultExpression);

            var resultValues = testingList.AsQueryable().Where(resultExpression).ToList();

            Assert.NotNull(resultValues);
            Assert.AreEqual(2, resultValues.Count);
        }

        [Test]
        public void GetFilteringExpressionWithInvalidDataTest() {
            Assert.Throws<ArgumentNullException>(() => ItemFilter.GetFilteringExpression(null));
            
            var nullDataFilter = new ItemFiltersParameters();

            var result = ItemFilter.GetFilteringExpression(nullDataFilter);
            Expression<Func<Item, bool>> expected = x => true;

            Assert.NotNull(result);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
    }
}
