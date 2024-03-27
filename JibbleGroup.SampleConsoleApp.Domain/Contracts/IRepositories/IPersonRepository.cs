
namespace JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Domain.Entities.Person>> GetAllAsync();
        IEnumerable<Domain.Entities.Person> SearchPersons(string keyword);
        Task<Domain.Entities.Person> FindPersonByUserName(string userName);
        Task Create(Domain.Entities.Person person);
        Task Delete(string userName);
    }
}
