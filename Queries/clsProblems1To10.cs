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
        public static void GetVehiclesBetweenYears(VehicleMakesDbContext context, int startYear, int endYear)
        {
            Console.WriteLine("Problem 1: Get all vehicles made between 1950 and 2000--\r\n");
            Console.WriteLine("Solution of Problem 1--\r\n");

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

    }
}
