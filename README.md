# MarketPlace
This project contains a rudimentary .NET Core-based Web API, a React-based web-application, and a folder that contains some documentation regarding the project requirements.
The purpose of this solution is to demonstrate a web-client's communication with a RESTful Web API. The Web API facilitates communication between the client and a MS SQLExpress database.
The provided Web API only provides route that allow the client to GET. There is no means, currently, to POST or DELETE data.

## Installation and Usage
You will need the following:
- An instance of SQLExpress Server hosting a databse called "Titles"
- Visual Studio (I used 2019) or some other means of running the Web API (which is based on .NET Core)
- Node.js and NPM, to run the Web-Client

You will want to open the Web API project and replace any instance of "Server=DESKTOP-HUE2\\SQLEXPRESS; Database=Titles; Trusted_Connection=True; MultipleActiveResultSets=true" with a connection string
that is more appropriate for your machine, however you have your instance configured.

To run the Web API, assuming that you are using Visual Studio 2019, please open the solution file "" and be sure that Marketplace.API is set as the start-up project. And then run the application using 
IIS Express (Debug with Any CPU selected should be fine). A blank page may open on your default browser. This is irrelevant. 
Please note that the Web API runs out of port 44356 on localhost. 

To run the Web Client, please open command-line and navigate to the folder "Marketplace.Web". From there, run the command "npm install" to grab all of the dependencies that the Web Client requires. Afterwards, you may run the command "npm start" to start a development instance of the application, which runs on port 8081 or the localhost.

The two ports mentioned are important, because the Web API has a CORS policy that allows requests from the Web Client's origin. If you must change this for any reason, please change this where necessary
in the Web API's Startup.cs file, under the Configuration of Services.

After the Web Client starts, you may navigate (if it didn't automatically) to localhost:8081 to view the home page.  


