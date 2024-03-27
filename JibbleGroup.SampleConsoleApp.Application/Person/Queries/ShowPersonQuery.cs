using JibbleGroup.SampleConsoleApp.Application.Dtos;
using MediatR;

namespace JibbleGroup.SampleConsoleApp.Application.Person.Queries
{
    public class ShowPersonQuery : IRequest<PersonFullDto>
    {
        public string UserName { get; set; }
    }
}
