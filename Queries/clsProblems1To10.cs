using EF_Practice_1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice_1.Queries
{
    internal class clsProblems1To10
    {
        //problem 1
        public static void GetVehiclesBetweenYears(VehicleMakesDbContext context, int startYear, int endYear)
        {
            Console.WriteLine("Problem 1: Get all vehicles made between 1950 and 2000--");
            Console.WriteLine("Solution of Problem 1--");

            var query = context.VehicleMasterDetails
                .Where(vehicle => vehicle.Year >= 1950 && vehicle.Year <= 2000)
                .Select(vehicle => new
                {
                    vehicle.Id,
                    vehicle.Make,
                    vehicle.ModelName,
                    vehicle.Year,
                    vehicle.FuelTypeName,

                })
                .OrderBy(vehicle => vehicle.Year)
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Vehicles List:");
            Console.WriteLine("--------------");

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(
                    $"Id: {vehicle.Id}, " +
                    $"Name: {vehicle.Make} {vehicle.ModelName}, " +
                    $"Year: {vehicle.Year}, " +
                    $"Fuel Type Name: {vehicle.FuelTypeName}, "
                );
            }
        }

        //problem 2
        public static void GetNumberVehiclesBetweenYears(VehicleMakesDbContext context, int startYear, int endYear)
        {
            Console.WriteLine("\nProblem 2: Get number vehicles made between 1950 and 2000--");
            Console.WriteLine("Solution of Problem 2--");

            var query = context.VehicleMasterDetails
                .Where(vehicle => vehicle.Year >= 1950 && vehicle.Year <= 2000);

            var numberVehicles = query.Count();
            Console.WriteLine($"Number of vehicles between {startYear} and {endYear}: {numberVehicles}");

        }

        //Problem 3
        public static void GetVehiclesBetweenYearsGroupedByMake(VehicleMakesDbContext context, int startYear, int endYear)
        {
            Console.WriteLine("Problem 3 : Get number vehicles made between 1950 and 2000 per make and order them by Number Of Vehicles Descending--");
            Console.WriteLine("Solution of Problem 3--");

            var query = context.VehicleMasterDetails
                .Where(vehicle => vehicle.Year >= 1950 && vehicle.Year <= 2000)
                .GroupBy(vehicle => vehicle.Make)
                .Select(group => new
                {
                    make = group.Key,
                    numberOfFields = group.Count()

                })
                .OrderByDescending(result => result.numberOfFields)
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Makes List:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine($"Make: {item.make}, Number Of Fields: {item.numberOfFields}");
            }
        }

        //Problem 4
        public static void GetVehiclesBetweenYearsGroupedByMakeMoreThanNumber(VehicleMakesDbContext context, int startYear, int endYear, int number)
        {
            Console.WriteLine("Problem 4 : Get All Makes that have manufactured more than 12000 Vehicles in years 1950 to 2000\r\n--");
            Console.WriteLine("Solution of Problem 3--");

            var query = context.VehicleMasterDetails
                .Where(vehicle => vehicle.Year >= 1950 && vehicle.Year <= 2000)
                .GroupBy(vehicle => vehicle.Make)
                .Where(group => group.Count() > number)
                .Select(groupeResults => new
                {
                    make = groupeResults.Key,
                    numberOfFields = groupeResults.Count()

                })
             
                .OrderByDescending(selectedResults => selectedResults.numberOfFields);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Makes List:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine($"Make: {item.make}, Number Of Fields: {item.numberOfFields}");
            }
        }


        //Problem 5
        public static void GetVehiclesBetweenYearsGroupedByMakeWithTotalVehicles(VehicleMakesDbContext context, int startYear, int endYear)
        {
            Console.WriteLine("Problem 5 : Get number of vehicles made between 1950 and 2000 per make and add total vehicles column beside--");
            Console.WriteLine("Solution of Problem 5--");

            var query = context.VehicleMasterDetails
                .Where(vehicle => vehicle.Year >= 1950 && vehicle.Year <= 2000)
                .GroupBy(vehicle => vehicle.Make)
                .Select(group => new
                {
                    make = group.Key,
                    numberOfVehicleBetweenYears = group.Count(),
                    totalVehiculesPerMake = context.VehicleMasterDetails.Count(v2 => v2.Make == group.Key),
                })
                .OrderByDescending(result => result.numberOfVehicleBetweenYears)
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Makes List:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine($"Make: {item.make}," +
                    $" Number Of Fields: {item.numberOfVehicleBetweenYears}, " +
                    $"total Vehicules : {item.totalVehiculesPerMake}");
            }
        }


        //Problem 6
        public static void GetVehiclesBetweenYearsGroupedByMakeWithTotalVehiclesWithPercentage(VehicleMakesDbContext context, int startYear, int endYear)
        {
            Console.WriteLine("Problem 6 : Get number of vehicles made between 1950 and 2000 per make and add total vehicles column beside--");
            Console.WriteLine("Solution of Problem 6--");

            var query = context.VehicleMasterDetails
                .Where(vehicle => vehicle.Year >= 1950 && vehicle.Year <= 2000)
                .GroupBy(vehicle => vehicle.Make)
                .Select(group => new
                {
                    make = group.Key,
                    numberOfVehicleBetweenYears = group.Count(),
                    totalVehiculesPerMake = context.VehicleMasterDetails.Count(v2 => v2.Make == group.Key),
                })
                .Select(r => new
                {
                    r.make,
                    r.numberOfVehicleBetweenYears,
                    r.totalVehiculesPerMake,
                    Percentage = Math.Round((r.numberOfVehicleBetweenYears * 100.0) / r.totalVehiculesPerMake, 2)
                })
                .OrderByDescending(result => result.numberOfVehicleBetweenYears)
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Makes List:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine($"Make: {item.make}," +
                    $" Number Of Fields: {item.numberOfVehicleBetweenYears}, " +
                    $"total Vehicules : {item.totalVehiculesPerMake}, " +
                    $"Percentage : {item.Percentage} %");
            }
        }

        //Problem 7
        public static void GetMakeFuelTypeNameNumberOfVehiclesPerMakeAndFuelTypeName(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 7 : Get Make, FuelTypeName and Number of Vehicles per FuelType per Make\r\n--");
            Console.WriteLine("Solution of Problem 7--");

            var query = context.VehicleMasterDetails
                .GroupBy(vehicle => new { vehicle.Make, vehicle.FuelTypeName })
                .Select(group => new
                {
                    make = group.Key.Make,
                    fuelTypeName = group.Key.FuelTypeName,
                    numberOfVehicles = group.Count(),
                })
                .OrderBy(results => results.make)
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Makes List:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine($"Make: {item.make}," +
                    $"fuel Type Name: {item.fuelTypeName}, " +
                    $"number Of Vehicles : {item.numberOfVehicles}");
            }
        }


        //Problem 8
        public static void GetAllVehiclesRunWithGAS(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 8 : Get 20 Make, ModelName and FuelTypeName that runs with GAS\r\n--");
            Console.WriteLine("Solution of Problem 8--");

            var query = context.VehicleMasterDetails
                .Where(vehilce => vehilce.FuelTypeName == "GAS")
                .Select(results => new
                {
                    make = results.Make,
                    modelName = results.ModelName,
                    fuelTypeName = results.FuelTypeName,
                })
                .OrderBy(results => results.make)
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Makes List:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine($"Make: {item.make}," +
                    $"model Name: {item.modelName}, " +
                    $"fuel Type Name: {item.fuelTypeName}");
            }
        }

        //Problem 9
        public static void GetTotalMakesRunWithGAS(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 9 : Get Total Makes that runs with GAS\r\n--");
            Console.WriteLine("Solution of Problem 9--");

            var query = context.VehicleMasterDetails
                .Where(vehilce => vehilce.FuelTypeName == "GAS");
                


            int totalMakes = query.AsNoTracking().Count();

            // If no data exists, stop here
            if (totalMakes == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Makes List:");
            Console.WriteLine("--------------");

            Console.WriteLine($"Total Makes : {totalMakes}");
        }

        //Problem 10
        public static void GetMakeAndNumberOfVehiclesOrderedDesc(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 10 : Count Vehicles by make and order them by NumberOfVehicles from high to low.\r\n--");
            Console.WriteLine("Solution of Problem 10--");

            var query = context.VehicleMasterDetails
                .GroupBy(group => group.Make)
                .Select(results => new
                {
                    make = results.Key,
                    numberOfVehicles = results.Count()
                })
                .OrderByDescending(selectedResult => selectedResult.numberOfVehicles)
                .Take(20);



            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Makes List:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine($"Make: {item.make}," +
                    $"number of Vehicules : {item.numberOfVehicles}");
            }
        }


    }
}
