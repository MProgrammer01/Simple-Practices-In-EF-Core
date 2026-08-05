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

clsProblems1To10.GetVehiclesBetweenYearsGroupedByMake(context, 1950, 2000);

clsProblems1To10.GetVehiclesBetweenYearsGroupedByMakeMoreThanNumber(context, 1950, 2000, 12000);

clsProblems1To10.GetVehiclesBetweenYearsGroupedByMakeWithTotalVehicles(context, 1950, 2000);

clsProblems1To10.GetVehiclesBetweenYearsGroupedByMakeWithTotalVehiclesWithPercentage(context, 1950, 2000);

clsProblems1To10.GetMakeFuelTypeNameNumberOfVehiclesPerMakeAndFuelTypeName(context);

clsProblems1To10.GetAllVehiclesRunWithGAS(context);

clsProblems1To10.GetTotalMakesRunWithGAS(context);

clsProblems1To10.GetMakeAndNumberOfVehiclesOrderedDesc(context);

Console.WriteLine("\nProblems From 11 To 20");

clsProblems11To20.GetAllMakesAndCountVehiclesMoreThan(context, 20000);

clsProblems11To20.GetAllMakesStartWithChar(context, "B");

clsProblems11To20.GetAllMakesEndWithChar(context, "W");

clsProblems11To20.GetAllMakesThatHaveDriveTypeNameIs(context, "FWD");

clsProblems11To20.GetTotalMakesThatHaveDriveTypeNameIs(context, "FWD");

clsProblems11To20.GetTotalVehiclesPerMakeAndDriveTypeName(context);

clsProblems11To20.GetTotalVehiclesPerMakeAndDriveTypeNameMoreThan(context, 10000);

clsProblems11To20.GetVehiclesThatNumberOfDoorsIsNull(context);

clsProblems11To20.GetTotalVehiclesThatNumberOfDoorsIsNull(context);

clsProblems11To20.GetPercentageVehiclesThatNumberOfDoorsIsNull(context);

Console.WriteLine("\nProblems From 21 To 30");

clsProblems21To30.GetVehiclesThatHaveSubModelName(context, "Elite");

clsProblems21To30.GetAllVehiclesThatHaveEnginesAndDoorsMoreThan(context, 3, 2);

clsProblems21To30.GetMakeAndVehiclesThatHaveEnginesContainAndHaveCylindersNumber(context, "OHV", 4);

static void PreviewSQLUsingLogin(string SQLString)
{
    Console.WriteLine("Preview SQL using Log:");
    Console.WriteLine("----------------------------------");
    Console.WriteLine(SQLString);
    Console.WriteLine();
}
