using JibbleGroup.SampleConsoleApp.Application.Dtos;
using MediatR;

namespace JibbleGroup.SampleConsoleApp.Application.Person.Queries
{
    public class SearchPersonsQuery : IRequest<List<PersonDto>>
    {
        public string Keyword { get; set; }
    }
}
