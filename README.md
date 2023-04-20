The application is for searching movie and books.
It is build on as ASP.NET core web app use external api  http://www.omdbapi.com, https://www.googleapis.com
# The steps for starting the app locally:
 requrments: vs2022, ms sql server >=2019
 create key in http://www.omdbapi.com then set value OMDbApiKey in appsettings in Search.Test.Web project 
 create SearchTest database in ms sql server and set connection string in appsettings in Search.Test.Web project 
 run migration in Search.Test.Infrastructure project with Update-Database command
 set Search.Test.Web project as startup project
