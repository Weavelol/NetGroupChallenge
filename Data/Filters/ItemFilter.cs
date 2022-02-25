using Data.FilterParameters;
using Core.Models;
using System.Linq.Expressions;
using LinqKit;

namespace Data.Filters {
    public static class ItemFilter {
        public static Expression<Func<Item, bool>> GetFilteringExpression(ItemFiltersParameters filter) {
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
                filteringExpression = filteringExpression.And(x => x.Weight == filter.Length);
            }
            if (filter.Width >= 0) {
                filteringExpression = filteringExpression.And(x => x.Weight == filter.Width);
            }
            if (filter.Height >= 0) {
                filteringExpression = filteringExpression.And(x => x.Weight == filter.Height);
            }


            if (filteringExpression == original) {
                filteringExpression = x => true;
            }

            return filteringExpression;
        }

    }
}
