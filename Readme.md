
# Sport Center API

Backend for the management of an sports centre bookings developed using .net Core 2.2 and Swagger.

## Getting Started

These instructions will provide you with a copy of this project running on your local machine for development and testing purposes.

### Prerequisites

Visual Studio 2017.
Microsoft .NET Core SDK 2.2.102
Microsoft SQL Server


### Installing

1. Clone or download the repository by clicking the Clone or download button.
2. Database:
	- Manual Creation Option
	   - In MS SQL Server creates a new user 'SportCenter'
		- Run the Create.sql script (SportCenterAPI/Scripts/Create.sql)
		- Run the DataInsert.sql script (SportCenterAPI/Scripts/DataInsert.sql)
	- From migrations
		- Do the 4 Step
		- Open the 'Package Manage Console' and run the command 'Update-Database'
3. Open the SportCenterAPI.sln solution file in Visual Studio 2017
4. Edit the SportCenterAPI/appsettings.json to change the DataBase Connection parameters


## Running the App
1. Open the SportCenterAPI.sln solution file in Visual Studio 2017
2. Rebuild the Solution
3. Run the app in the IIS Express
4. In order to test it with Swagger, access to the URL https://localhost:44331/swagger/

## Running unit tests

1. Open the project with Visual Studio
2. Rebuild the solution
3. In the Test Explorer window select 'Run All'

## Built With

* [.Net Core](https://docs.microsoft.com/en-gb/dotnet/) - The framework used to develop the Rest API
* [Nuget](https://docs.microsoft.com/en-us/nuget/) - Dependency Management
* [Swagger](https://swagger.io/docs/) - Used to documents and tests the API

## Author

* **Juan Pablo Rodríguez Valentín** - [Juampiii](https://github.com/juampiii)
