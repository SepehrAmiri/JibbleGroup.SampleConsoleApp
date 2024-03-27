using JibbleGroup.SampleConsoleApp.Application.Person.Commands;
using JibbleGroup.SampleConsoleApp.Application.Person.Queries;
using JibbleGroup.SampleConsoleApp.Domain.Enumerations;
using JibbleGroup.SampleConsoleApp.Presentation.Enumerations;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JibbleGroup.SampleConsoleApp.Presentation
{
    public class ConsoleApp : IHostedService
    {
        private readonly ISender _sender;

        public ConsoleApp(ISender sender)
        {
            _sender = sender;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Commands command = Commands.ListPeople;
            while (command != Commands.Exit)
            {
                try
                {
                    command = ShowMenu();
                    await ProcessCommand(command);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("Kindly press a key to return . . .");
                    Console.ReadKey(false);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Commands ShowMenu()
        {
            object command;

            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine((int)Commands.ListPeople + ": List People");
            Console.WriteLine((int)Commands.Search + ": Search People");
            Console.WriteLine((int)Commands.ShowPerson + ": Specific Person Details");
            Console.WriteLine((int)Commands.CreatePerson + ": Create New Person");
            Console.WriteLine((int)Commands.DeletePerson+ ": Delete Existing Person");
            Console.WriteLine("");
            Console.WriteLine((int)Commands.Exit + ": Exit");
            Console.WriteLine("");

            while (true)
            {
                var key = Console.ReadKey();
                if (Enum.TryParse(typeof(Commands), key.KeyChar.ToString(), out command))
                    break;

                Console.WriteLine(" -> The command is not valid");
            }

            return (Commands)command;
        }

        private async Task ProcessCommand(Commands command)
        {
            switch (command)
            {
                case Commands.ListPeople:
                    await ShowPeopleList();
                    break;
                case Commands.Search:
                    await SearchPeople();
                    break;
                case Commands.ShowPerson:
                    await ShowPerson();
                    break;
                case Commands.CreatePerson:
                    await CreatePerson();
                    break;
                case Commands.DeletePerson:
                    await DeletePerson();
                    break;
            }
        }

        private async Task ShowPeopleList()
        {
            Console.Clear();
            var people = await _sender.Send(new GetAllPersonsQuery());

            Console.WriteLine("List People");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("UserName: FirstName LastName");
            Console.WriteLine("-----------------------------------");

            foreach (var person in people)
            {
                Console.WriteLine("{0}: {1} {2}", person.UserName, person.FirstName, person.LastName);
            }
            Console.WriteLine();
            Console.WriteLine("Kindly press a key to return . . .");
            Console.ReadKey(false);
        }

        private async Task SearchPeople()
        {
            Console.Clear();

            Console.WriteLine("Kindly input a fragment of the username, first name, or last name to proceed:");
            var keyword = Console.ReadLine();

            var people = await _sender.Send(new SearchPersonsQuery() { Keyword = keyword ?? "" });

            Console.WriteLine("Result:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("UserName: FirstName LastName");
            Console.WriteLine("-----------------------------------");

            foreach (var person in people)
            {
                Console.WriteLine("{0}: {1} {2}", person.UserName, person.FirstName, person.LastName);
            }
            Console.WriteLine();
            Console.WriteLine("Kindly press a key to return . . .");
            Console.ReadKey(false);
        }

        private async Task ShowPerson()
        {
            Console.Clear();

            Console.WriteLine("Please provide the precise username to continue:");
            var userName = Console.ReadLine();

            var person = await _sender.Send(new ShowPersonQuery() { UserName = userName ?? "" });

            Console.WriteLine("Result:");
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("UserName: " + person.UserName);
            Console.WriteLine("FirstName: " + person.FirstName);
            Console.WriteLine("LastName: " + person.LastName);
            Console.WriteLine("MiddleName: " + person.MiddleName);
            Console.WriteLine("Gender: " + person.Gender);
            Console.WriteLine("Age: " + person.Age);

            Console.WriteLine("Emails: ");
            foreach(var email in person.Emails)
                Console.WriteLine("\t" + email);
            
            Console.WriteLine("AddressInfo: ");
            foreach(var address in person.AddressInfo)
                Console.WriteLine("\t" + address.Address + ", " + 
                                            address.City?.CountryRegion + ", " + 
                                            address.City?.Region + ", " + 
                                            address.City?.Name);

            Console.WriteLine("HomeAddress: " +
                                        (person.HomeAddress?.Address == null ? "" :
                                            (person.HomeAddress?.Address + ", " +
                                            person.HomeAddress?.City?.CountryRegion + ", " +
                                            person.HomeAddress?.City?.Region + ", " +
                                            person.HomeAddress?.City?.Name)));

            Console.WriteLine("FavoriteFeature: " + person.FavoriteFeature);
            Console.WriteLine("Features: ");
            foreach (var Feature in person.Features)
                Console.WriteLine("\t" + Feature);

            Console.WriteLine();
            Console.WriteLine("Kindly press a key to return . . .");
            Console.ReadKey(false);
        }

        private async Task CreatePerson()
        {
            var command = new CreatePersonCommand();
            Console.Clear();
            Console.Write("UserName: ");
            command.UserName = Console.ReadLine() ?? throw new Exception("UserName is required!");

            Console.Write("FirstName: ");
            command.FirstName = Console.ReadLine() ?? throw new Exception("FirstName is required!");

            Console.Write("Gender: ");
            object gender;
            if (Enum.TryParse(typeof(PersonGender), Console.ReadLine(), out gender))
                command.Gender = (PersonGender)gender;
            else
                throw new Exception("Gender is not valid!");

            Console.Write("FavoriteFeature: ");
            object favoriteFeature;
            if (Enum.TryParse(typeof(Feature), Console.ReadLine(), out favoriteFeature))
                command.FavoriteFeature = (Feature)favoriteFeature;
            else
                throw new Exception("FavoriteFeature is not valid!");

            await _sender.Send(command);
        }

        private async Task DeletePerson()
        {
            Console.Clear();
            Console.WriteLine("Kindly input a fragment of the username, first name, or last name to proceed:");
            var UserName = Console.ReadLine();

            var command = new DeletePersonCommand()
            {
                UserName = UserName ?? ""
            };
            await _sender.Send(command);
        }
    }
}
