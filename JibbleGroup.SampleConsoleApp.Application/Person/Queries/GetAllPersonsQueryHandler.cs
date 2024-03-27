using JibbleGroup.SampleConsoleApp.Application.Dtos;
using JibbleGroup.SampleConsoleApp.Application.Mapper;
using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using MediatR;
namespace JibbleGroup.SampleConsoleApp.Application.Person.Queries
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, List<PersonDto>>
    {
        IPersonRepository personRepository;

        public GetAllPersonsQueryHandler(IPersonRepository _personRepository)
        {
            personRepository = _personRepository;
        }

        public async Task<List<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await personRepository.GetAllAsync();
            return persons.ToDto().ToList();
        }
    }
}
