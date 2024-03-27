using Trippin;

namespace JibbleGroup.SampleConsoleApp.Infrastructure.Mapper
{
    internal static class LocationMapper
    {
        public static Domain.ValueObjects.Location ToValueObject(this Location location)
        {
            return new Domain.ValueObjects.Location
            {
                Address = location.Address,
                City = location.City?.ToValueObject()
            };
        }

        public static List<Domain.ValueObjects.Location> ToValueObject(this List<Location> locations)
        {
            return locations.Select(x=>x.ToValueObject()).ToList();
        }
    }
}
