using JibbleGroup.SampleConsoleApp.Application.Dtos;
using JibbleGroup.SampleConsoleApp.Application.Mapper;
using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using MediatR;

namespace JibbleGroup.SampleConsoleApp.Application.Person.Queries
{
    public class ShowPersonQueryHandler : IRequestHandler<ShowPersonQuery, PersonFullDto>
    {
        IPersonRepository personRepository;

        public ShowPersonQueryHandler(IPersonRepository _personRepository)
        {
            personRepository = _personRepository;
        }

        public async Task<PersonFullDto> Handle(ShowPersonQuery request, CancellationToken cancellationToken)
        {
            var persons = await personRepository.FindPersonByUserName(request.UserName);
            return persons.ToPersonFullDto();
        }
    }
}
