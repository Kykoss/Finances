using System.Collections.ObjectModel;

namespace Finanzknabe.Dal.Extensions
{
    public static class IQueryableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IQueryable<T> set)
        {
            var collection = new ObservableCollection<T>();
            foreach (var item in set)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
