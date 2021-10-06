[![Emata Uganda](https://assets.website-files.com/5e6609a9bc2ae58563237baf/5e662b804fda926f371531c6_Asset%202mdpi.png)](https://www.emata.ug/)

Generic Reporting Tool
======================

Generic Reporting Tool is a `.NET 5 Web API` that lets users upload sales entries to a SQLite database from a provided sales entries file(located in `Files` folder in the root directory of the solution). 

Users can also query the sales entries from the database.

## Get Started

Clone this repository to your machine and setup a local working copy.

We recommend you use any version of `Visual Studio 2019 (The Community Edition is free!)` to restore nuget packages, build and run the solution. 

`The API project is the startup project.`

You can also use `Visual Studio Code` or `Rider IDE`.

`If you choose to use Visual Studio Code, use the .NET CLI to restore packages, build and run the solution`.

## .NET CLI Basic Usage

First, you will need to restore the packages:
	
	dotnet restore
	
Second, you will build the solution:
	
	dotnet build

Then run the solution:

	Windows:
	
	dotnet run --project .\API\API.csproj
	
	Linux:
	
	dotnet run --project ./API/API.csproj
	
`The API docs are accessible at https://localhost:5001/swagger`
	
## N.B

`Do not make any pull requests to this repository or fork it. Follow the instructions given in the associated document.`
