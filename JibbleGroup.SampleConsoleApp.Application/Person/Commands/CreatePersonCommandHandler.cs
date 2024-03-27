using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using MediatR;

namespace JibbleGroup.SampleConsoleApp.Application.Person.Commands
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        IPersonRepository personRepository;

        public CreatePersonCommandHandler(IPersonRepository _personRepository)
        {
            personRepository = _personRepository;
        }

        public Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Domain.Entities.Person
            {
                AddressInfo = request.AddressInfo,
                Age = request.Age,
                Emails = request.Emails,
                FirstName = request.FirstName,
                FavoriteFeature = request.FavoriteFeature, 
                Features = request.Features,
                Gender = request.Gender,
                HomeAddress = request.HomeAddress,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                UserName = request.UserName
            };
            return personRepository.Create(person);
        }
    }
}
