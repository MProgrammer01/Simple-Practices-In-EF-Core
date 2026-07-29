using EF_Practice_1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice_1.Queries
{
    internal class clsProblems11To20
    {
        //problem 1
        public static void GetAllMakesAndCountVehiclesMoreThan(VehicleMakesDbContext context, int number)
        {
            Console.WriteLine("Problem 1: Get all Makes/Count Of Vehicles that manufactures more than 20K Vehicles--");
            Console.WriteLine("Solution of Problem 1--");


            var query = context.VehicleMasterDetails
                .GroupBy(group => group.Make)
                .Where(resultsGroup => resultsGroup.Count() > number)
                .Select(result => new
                {
                    make = result.Key,
                    totalVehicles = result.Count(),

                });


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
                    $"Make: {vehicle.make}, " +
                    $"Total Vehicles: {vehicle.totalVehicles}"
                );
            }
        }

    }
}
