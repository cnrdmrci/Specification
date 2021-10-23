using System;
using System.Linq.Expressions;
using Specification;
using SpecificationSampleApi.Model;

namespace SpecificationSampleApi.CarSpecifications
{
    public class ColorShould : AbstractSpecification<Car>
    {
        private ColorShould(Expression<Func<Car, bool>> expression) : base(expression)
        {
        }

        public static ISpecification<Car> BeColor(string color) => new ColorShould(x => x.Color == color);
        public static ISpecification<Car> BeColorWhite() => new ColorShould(x => x.Color == "White");
        public static ISpecification<Car> BeColorRed() => new ColorShould(x => x.Color == "Red");
        public static ISpecification<Car> BeColorBlue() => new ColorShould(x => x.Color == "Blue");
    }
}