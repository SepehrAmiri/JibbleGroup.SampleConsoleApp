# OData People Explorer (JibbleGroup.SampleConsoleApp)

## Introduction
OData People Explorer is a C# console application that interacts with the public OData API v4. It's designed to demonstrate clean architecture principles, Domain-Driven Design (DDD), and best practices in software development.

## Features
•  [**List People**]: Retrieve and display a list of people from the OData service.

•  [**Search People**]: Allows users to search for people by name or other criteria.

•  [**Person Details**]: View detailed information about a specific person.

•  [**Create New Person**]: Add a new person to the OData service.

•  [**Delete Existing Person**]: Remove a person's details from the OData service.


## Getting Started
To run the OData People Explorer, follow these steps:

1. Clone the repository to your local machine.
2. Ensure you have [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later installed.
3. Navigate to the project directory in your terminal.
4. Run `dotnet restore` to install necessary packages.
5. Execute `dotnet run` to start the application.

## Architecture
This project follows Clean Architecture principles, structured into the following layers:

•  [**Domain**]: Contains the business logic and entities.

•  [**Application**]: Handles use cases and application logic.

•  [**Infrastructure**]: Manages data persistence and external concerns.

•  [**Presentation**]: The console interface for user interaction.


## Technologies
•  **C#**: The primary programming language used.

•  [**OData Connected Service 2022**]: For consuming OData services.

•  [**MediatR**]: For implementing CQRS pattern.

•  [**Dependency Injection**]: Built-in .NET Core feature used for DI.


## Contributing
Contributions are welcome. Please open an issue first to discuss what you would like to change or add.


## License
MIT License

Copyright (c) [year] [copyright holders]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
