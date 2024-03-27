using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using MediatR;

namespace JibbleGroup.SampleConsoleApp.Application.Person.Commands
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        IPersonRepository personRepository;

        public DeletePersonCommandHandler(IPersonRepository _personRepository)
        {
            personRepository = _personRepository;
        }

        public Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return personRepository.Delete(request.UserName);
        }
    }
}
