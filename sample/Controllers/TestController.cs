using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SpecificationSampleApi.Model;
using Specification;
using SpecificationSampleApi.CarSpecifications;
using System.Linq;

namespace SpecificationSampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly List<Car> _cars;

        public TestController()
        {
            _cars = new List<Car>
            {
                new Car { Model = "CarModelA", ReleaseYear = 2016, Color = "White", Type = "Sport" },
                new Car { Model = "CarModelC", ReleaseYear = 2017, Color = "Blue", Type = "Classic" },
                new Car { Model = "CarModelA", ReleaseYear = 2018, Color = "Red", Type = "Classic" },
                new Car { Model = "CarModelC", ReleaseYear = 2019, Color = "Red", Type = "Classic" },
                new Car { Model = "CarModelB", ReleaseYear = 2020, Color = "White", Type = "Sport" },
                new Car { Model = "CarModelC", ReleaseYear = 2021, Color = "Red", Type = "Classic" }
            };
        }

        [HttpGet]
        public ActionResult<bool> Get()
        {
            var defaultSpecExp = DefaultSpecification<Car>.CreateDefault;

            var complexSpecExp = defaultSpecExp.And(ModelShould.BeModelC())
                                               .And(ReleaseYearShould.BeReleaseYearGreaterThan2019())
                                               .Or(ReleaseYearShould.BeReleaseYearEquals(2018))
                                               .And(ColorShould.BeColorRed())
                                               .And(TypeShould.BeTypeClassic());

            var filteredCarsQueryable = _cars.AsQueryable().WhereForSpecification(complexSpecExp);
            var filteredCarsEnumerable = _cars.AsEnumerable().WhereForSpecification(complexSpecExp);

            var filteredCarsForQueryable = filteredCarsQueryable.ToList();
            var filteredCarsForEnumerable = filteredCarsEnumerable.ToList();

            return Ok(true);
        }
    }
}
