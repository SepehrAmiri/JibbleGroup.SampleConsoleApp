using JibbleGroup.SampleConsoleApp.Application.Dtos;
using JibbleGroup.SampleConsoleApp.Application.Mapper;
using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using MediatR;
using System;

namespace JibbleGroup.SampleConsoleApp.Application.Person.Queries
{
    public class SearchPersonsQueryHandler : IRequestHandler<SearchPersonsQuery, List<PersonDto>>
    {
        IPersonRepository personRepository;

        public SearchPersonsQueryHandler(IPersonRepository _personRepository)
        {
            personRepository = _personRepository;
        }

        public Task<List<PersonDto>> Handle(SearchPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = personRepository.SearchPersons(request.Keyword);
            return Task.FromResult(persons.ToDto().ToList());
        }
    }
}
