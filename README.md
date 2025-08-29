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


//////////////////////////////////////////////////////////////////////////////////////////////
Step 1: Install Required NuGet Package

Run this command in your project folder:

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL


This installs the EF Core provider for PostgreSQL.

🔹 Step 2: Add Connection String in appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=MyAppDb;Username=postgres;Password=yourpassword"
  }
}


⚠️ Replace yourpassword with your actual PostgreSQL password.

🔹 Step 3: Create Your DbContext

Inside your Data folder (create if not exists), make a file DbContextApplication.cs:

using Microsoft.EntityFrameworkCore;
using WebApplicationWithDB.Models;

namespace WebApplicationWithDB.Data
{
    public class DbContextApplication : DbContext
    {
        public DbContextApplication(DbContextOptions<DbContextApplication> options) : base(options)
        {
        }

        // Add DbSets for your entities
        public DbSet<Employee> Employees { get; set; }
    }
}

🔹 Step 4: Create a Model (e.g., Employee.cs inside Models folder)
using System;

namespace WebApplicationWithDB.Models
{
    public class Employee
    {
        public Guid Id { get; set; }   // Primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}

🔹 Step 5: Register DbContext in Program.cs
using Microsoft.EntityFrameworkCore;
using WebApplicationWithDB.Data;

var builder = WebApplication.CreateBuilder(args);

// Add PostgreSQL DbContext
builder.Services.AddDbContext<DbContextApplication>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();

🔹 Step 6: Add EF Core Tools (if not already installed)
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design

🔹 Step 7: Run Migrations

👉 In Package Manager Console (Visual Studio) or terminal (VS Code / CLI):

# Create a migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
