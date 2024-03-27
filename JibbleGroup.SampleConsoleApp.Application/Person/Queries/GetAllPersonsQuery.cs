using JibbleGroup.SampleConsoleApp.Application.Dtos;
using MediatR;

namespace JibbleGroup.SampleConsoleApp.Application.Person.Queries
{
    public class GetAllPersonsQuery : IRequest<List<PersonDto>>
    {
    }
}
