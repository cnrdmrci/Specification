using System;
using System.Linq.Expressions;
using Specification;
using SpecificationSampleApi.Model;

namespace SpecificationSampleApi.CarSpecifications
{
    public class ModelShould : AbstractSpecification<Car>
    {
        private ModelShould(Expression<Func<Car, bool>> expression) : base(expression)
        {
        }

        public static ISpecification<Car> BeModel(string carModel) => new ModelShould(x => x.Model == carModel);
        public static ISpecification<Car> BeModelA() => new ModelShould(x => x.Model == "CarModelA");
        public static ISpecification<Car> BeModelB() => new ModelShould(x => x.Model == "CarModelB");
        public static ISpecification<Car> BeModelC() => new ModelShould(x => x.Model == "CarModelC");
    }
}