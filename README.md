The application is for searching movie and books.
It is build as ASP.NET core web app https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps use external api  http://www.omdbapi.com, https://www.googleapis.com
# The steps for starting the app locally:
 1) requrments: vs2022, ms sql server >=2019
 2) create key in http://www.omdbapi.com then set value OMDbApiKey in appsettings in Search.Test.Web project 
 3) create SearchTest database in ms sql server and set connection string in appsettings in Search.Test.Web project 
 4) run migration in Search.Test.Infrastructure project with Update-Database command
 5) set Search.Test.Web project as startup project
