using Trippin;
using AppEnums = JibbleGroup.SampleConsoleApp.Domain.Enumerations;

namespace JibbleGroup.SampleConsoleApp.Infrastructure.Mapper
{
    internal static class PersonMapper
    {
        public static IEnumerable<Domain.Entities.Person> ToEntity(this IEnumerable<Person> persons)
        {
            return persons.Select(x=>x.ToEntity());
        }

        public static Domain.Entities.Person ToEntity(this Person person)
        {
            return new Domain.Entities.Person
            {
                UserName = person.UserName,
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                Age = person.Age,
                Emails = person.Emails.ToList(),
                Gender = (AppEnums.PersonGender)Enum.Parse(typeof(AppEnums.PersonGender), person.Gender.ToString()),
                FavoriteFeature = (AppEnums.Feature)Enum.Parse(typeof(AppEnums.Feature), person.FavoriteFeature.ToString()),
                Features = person.Features.Select(x => (AppEnums.Feature)Enum.Parse(typeof(AppEnums.Feature), x.ToString())).ToList(),
                HomeAddress = person.HomeAddress?.ToValueObject(),
                AddressInfo = person.AddressInfo.ToList().ToValueObject()
            };
        }

    }
}
