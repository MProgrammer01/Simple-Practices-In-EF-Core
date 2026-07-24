// EF Core namespace
using Microsoft.EntityFrameworkCore;


// Configuration namespaces
using Microsoft.Extensions.Configuration;


// Your DbContext namespace
using EF_Practice_1.Data;

using System.Diagnostics;
using Microsoft.Extensions.Logging;
using EF_Practice_1.Queries;

// Build configuration object so the console app can read appsettings.json
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // Look for files in current folder
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load appsettings.json
    .Build();


// Read the connection string from the ConnectionStrings section
string? connectionString = configuration.GetConnectionString("DefaultConnection");

// Check that connection string was found successfully
if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("Connection string 'DefaultConnection' was not found.");
    return;
}

/// Build DbContextOptions manually for AppDbContext
var options = new DbContextOptionsBuilder<VehicleMakesDbContext>()
    .UseSqlServer(connectionString) // Tell EF Core to use SQL Server with this connection string
    //.LogTo(Console.WriteLine, LogLevel.Information)
    .LogTo(message => PreviewSQLUsingLogin(message), new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .Options;

// Create DbContext instance manually using the configured options
using var context = new VehicleMakesDbContext(options);

Console.WriteLine("This Is Problems In EF Core");

Console.WriteLine("Problems From 1 To 10");

clsProblems1To10.GetVehiclesBetweenYears(context, 1950, 2000);

clsProblems1To10.GetNumberVehiclesBetweenYears(context, 1950, 2000);

static void PreviewSQLUsingLogin(string SQLString)
{
    Console.WriteLine("Preview SQL using Login:");
    Console.WriteLine("----------------------------------");
    Console.WriteLine(SQLString);
    Console.WriteLine();
}
