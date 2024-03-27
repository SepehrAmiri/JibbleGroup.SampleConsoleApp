using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using JibbleGroup.SampleConsoleApp.Infrastructure.Mapper;
using Trippin;

namespace JibbleGroup.SampleConsoleApp.Infrastructure.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        string SERVICE_ROOT = "https://services.odata.org/TripPinRESTierService";

        TripPinContainer context;

        public PersonRepository() {
            context = new TripPinContainer(new Uri(SERVICE_ROOT));
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetAllAsync()
        {            
            IEnumerable<Person> people = await context.People.ExecuteAsync();
            return people.ToEntity();
        }

        public IEnumerable<Domain.Entities.Person> SearchPersons(string keyword)
        {
            IEnumerable<Person> people = context.People
                .Where(x => x.UserName.Contains(keyword) || x.FirstName.Contains(keyword) || x.LastName.Contains(keyword))
                .AsEnumerable();
            return people.ToEntity();
        }

        public async Task<Domain.Entities.Person> FindPersonByUserName(string userName)
        {
            var people = context.People.Where(x=>x.UserName == userName);

            if (people.Count() == 0)
                throw new Exception("No individuals with this Username were found!");

            Person person = await context.People.ByKey(userName: userName).GetValueAsync();
            return person.ToEntity();
        }

        public async Task Create(Domain.Entities.Person person)
        {
            var gender = (PersonGender)Enum.Parse(typeof(PersonGender), person.Gender.ToString());
            var favoriteFeature = (Feature)Enum.Parse(typeof(Feature), person.FavoriteFeature.ToString());
            var newPerson = Person.CreatePerson(person.UserName, person.FirstName, gender, favoriteFeature);
            context.AddToPeople(newPerson);
            await context.SaveChangesAsync();
        }

        public async Task Delete(string userName)
        {
            var people = context.People.Where(x => x.UserName == userName);

            if (people.Count() == 0)
                throw new Exception("No individuals with this Username were found!");

            Person person = await context.People.ByKey(userName: userName).GetValueAsync();
            context.DeleteObject(person);
            await context.SaveChangesAsync(); 
        }
    }
}
