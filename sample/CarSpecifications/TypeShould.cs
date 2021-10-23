using System;
using System.Linq.Expressions;
using Specification;
using SpecificationSampleApi.Model;

namespace SpecificationSampleApi.CarSpecifications
{
    public class TypeShould : AbstractSpecification<Car>
    {
        private TypeShould(Expression<Func<Car, bool>> expression) : base(expression)
        {
        }

        public static ISpecification<Car> BeType(string type) => new TypeShould(x => x.Type == type);
        public static ISpecification<Car> BeTypeClassic() => new TypeShould(x => x.Type == "Classic");
        public static ISpecification<Car> BeTypeSport() => new TypeShould(x => x.Type == "Sport");
    }
}