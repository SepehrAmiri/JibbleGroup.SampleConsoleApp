using MediatR;

namespace JibbleGroup.SampleConsoleApp.Application.Person.Commands
{
    public class DeletePersonCommand : IRequest
    {
        public string UserName { get; set; }
    }
}
