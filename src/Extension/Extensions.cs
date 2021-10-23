using System.Collections.Generic;
using System.Linq;

namespace Specification
{
    public static class Extensions
    {
        public static IEnumerable<TModel> WhereForSpecification<TModel>(this IEnumerable<TModel> models, ISpecification<TModel> spec)
        {
            models = models.Where(spec.IsSatisfiedBy);
            return models;
        }

        public static IQueryable<TModel> WhereForSpecification<TModel>(this IQueryable<TModel> models, ISpecification<TModel> spec)
        {
            models = models.Where(spec.GetExpression());
            return models;
        }
    }
}