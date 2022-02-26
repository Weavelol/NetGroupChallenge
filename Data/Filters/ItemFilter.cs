using Data.FilterParameters;
using Core.Models;
using System.Linq.Expressions;
using LinqKit;

namespace Data.Filters {
    /// <summary>
    /// ItemFilter used to create expressions to use in repository from FilterParameters Values
    /// </summary>
    public static class ItemFilter {

        /// <summary>
        /// Creates expression for Item-Query from item Filters
        /// </summary>
        /// <param name="filter">ItemFiltersParameters with filtering Data</param>
        /// <returns>Expression for LINQ query used in repository</returns>
        /// <exception cref="ArgumentNullException">filter parameter was null</exception>
        public static Expression<Func<Item, bool>> GetFilteringExpression(ItemFiltersParameters filter) {
            if (filter is null) {
                throw new ArgumentNullException(nameof(filter));
            }

            Expression<Func<Item, bool>>? filteringExpression = PredicateBuilder.New<Item>(true);
            var original = filteringExpression;

            if (!string.IsNullOrEmpty(filter.Title)) {
                filteringExpression = filteringExpression.And(x => x.Title.Contains(filter.Title));
            }
            if (!string.IsNullOrEmpty(filter.StorageTitle)) {
                filteringExpression = filteringExpression.And(x => 
                    x.ParentStorage.Title.Contains(filter.StorageTitle));
            }
            if (!string.IsNullOrEmpty(filter.SerialNumber)) {
                filteringExpression = filteringExpression.And(x => x.SerialNumber.Contains(filter.SerialNumber));
            }
            if (!string.IsNullOrEmpty(filter.Classification)) {
                filteringExpression = filteringExpression.And(x => x.Classification.Contains(filter.Classification));
            }
            if (!string.IsNullOrEmpty(filter.ItemOwner)) {
                filteringExpression = filteringExpression.And(x => x.ItemOwner.Contains(filter.ItemOwner));
            }
            if (filter.Weight >= 0) {
                filteringExpression = filteringExpression.And(x => x.Weight == filter.Weight);
            }
            if (filter.Length >= 0) {
                filteringExpression = filteringExpression.And(x => x.Length == filter.Length);
            }
            if (filter.Width >= 0) {
                filteringExpression = filteringExpression.And(x => x.Width == filter.Width);
            }
            if (filter.Height >= 0) {
                filteringExpression = filteringExpression.And(x => x.Height == filter.Height);
            }


            if (filteringExpression == original) {
                filteringExpression = x => true;
            }

            return filteringExpression;
        }

    }
}
