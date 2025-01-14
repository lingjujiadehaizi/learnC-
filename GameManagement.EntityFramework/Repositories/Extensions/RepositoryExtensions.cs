using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace GameManagement.EntityFramework.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<T> OrderByQuery<T>(this IQueryable<T> queryable, string queryString)
        {
            if (string.IsNullOrWhiteSpace(queryString))
            {
                return queryable;
            }
            var orderParams = queryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param)) { continue; }
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(p => p.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null) { continue; }
                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return queryable.OrderBy(orderQuery);
        }
    }
}
