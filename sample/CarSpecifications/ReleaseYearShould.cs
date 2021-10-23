using System;
using System.Linq.Expressions;
using Specification;
using SpecificationSampleApi.Model;

namespace SpecificationSampleApi.CarSpecifications
{
    public class ReleaseYearShould : AbstractSpecification<Car>
    {
        private ReleaseYearShould(Expression<Func<Car, bool>> expression) : base(expression)
        {
        }

        public static ISpecification<Car> BeReleaseYearEquals(int year) => new ReleaseYearShould(x => x.ReleaseYear == year);
        public static ISpecification<Car> BeReleaseYearGreaterThan2019() => new ReleaseYearShould(x => x.ReleaseYear > 2019);
        public static ISpecification<Car> BeReleaseYearLessThan2021() => new ReleaseYearShould(x => x.ReleaseYear < 2021);
        public static ISpecification<Car> BeReleaseYearEquals2020() => new ReleaseYearShould(x => x.ReleaseYear == 2020);
    }
}