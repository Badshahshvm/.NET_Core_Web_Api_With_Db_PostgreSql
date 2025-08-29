1. dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

//Add ConectionString in Appsetting.json

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=MyAppDb;Username=postgres;Password=yourpassword"
  }
}

3.  Run these commands in package mangaer console
      Add-Migration InitialCreate
        Update-Database
