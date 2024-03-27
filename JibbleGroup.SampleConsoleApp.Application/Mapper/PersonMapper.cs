using JibbleGroup.SampleConsoleApp.Application.Dtos;
using AppEnums = JibbleGroup.SampleConsoleApp.Domain.Enumerations;

namespace JibbleGroup.SampleConsoleApp.Application.Mapper
{
    internal static class PersonMapper
    {
        public static IEnumerable<PersonDto> ToDto(this IEnumerable<Domain.Entities.Person> persons)
        {
            return persons.Select(x=>x.ToDto());
        }

        public static PersonDto ToDto(this Domain.Entities.Person person)
        {
            return new PersonDto
            {
                UserName = person.UserName,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
        }

        public static PersonFullDto ToPersonFullDto(this Domain.Entities.Person person)
        {
            return new PersonFullDto
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
                HomeAddress = person.HomeAddress,
                AddressInfo = person.AddressInfo
            };
        }

    }
}
