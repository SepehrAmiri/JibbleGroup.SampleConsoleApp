using JibbleGroup.SampleConsoleApp.Domain.Enumerations;
using JibbleGroup.SampleConsoleApp.Domain.ValueObjects;

namespace JibbleGroup.SampleConsoleApp.Domain.Entities
{
    public class Person
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public PersonGender Gender { get; set; }
        public long? Age { get; set; }
        public List<string> Emails { get; set; }
        public Feature FavoriteFeature { get; set; }
        public List<Feature> Features { get; set; }
        public List<Location> AddressInfo { get; set; }
        public Location? HomeAddress { get; set; }
    }
}
