using Trippin;

namespace JibbleGroup.SampleConsoleApp.Infrastructure.Mapper
{
    internal static class CityMapper
    {
        public static Domain.ValueObjects.City ToValueObject(this City city)
        {
            return new Domain.ValueObjects.City
            {
                Name = city.Name,
                CountryRegion = city.CountryRegion,
                Region = city.Region
            };
        }
    }
}
