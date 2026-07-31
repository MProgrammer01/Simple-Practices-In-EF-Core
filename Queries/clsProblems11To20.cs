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

        //problem 2
        public static void GetAllMakesStartWithChar(VehicleMakesDbContext context, string character)
        {
            Console.WriteLine("Problem 2: Get all Makes with make starts with character\r\n--");
            Console.WriteLine("Solution of Problem 2--");


            var query = context.Makes
                .Where(make => make.MakeName.StartsWith(character))
                .Select(result => new
                {
                    make = result.MakeName,
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
                    $"Make: {vehicle.make},"
                );
            }
        }


        //problem 3
        public static void GetAllMakesEndWithChar(VehicleMakesDbContext context, string character)
        {
            Console.WriteLine("Problem 3: Get all Makes with make ends with character\r\n--");
            Console.WriteLine("Solution of Problem 3--");


            var query = context.Makes
                .Where(make => make.MakeName.EndsWith(character))
                .Select(result => new
                {
                    make = result.MakeName,
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
                    $"Make: {vehicle.make},"
                );
            }
        }


        //problem 4
        public static void GetAllMakesThatHaveDriveTypeNameIs(VehicleMakesDbContext context, string driveTypeName)
        {
            Console.WriteLine("Problem 4: Get all Makes that manufactures DriveTypeName = any type you want (from DB)\r\n--");
            Console.WriteLine("Solution of Problem 4--");


            var query = context.VehicleMasterDetails
                .Where(vehicle => vehicle.DriveTypeName.Equals(driveTypeName))
                .Select(result => new
                {
                    make = result.Make,
                    driveTypeName = result.DriveTypeName
                })
                .OrderBy(result => result.make)
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
                    $"Make: {vehicle.make}," +
                    $"Drive Type Name: {vehicle.driveTypeName},"
                );
            }
        }


        //problem 5
        public static void GetTotalMakesThatHaveDriveTypeNameIs(VehicleMakesDbContext context, string driveTypeName)
        {
            Console.WriteLine("Problem 5: Get total Makes that Mantufactures DriveTypeName=FWD\r\n\r\n--");
            Console.WriteLine("Solution of Problem 5--");


            var query = context.VehicleMasterDetails
                .Where(vehicle => vehicle.DriveTypeName.Equals(driveTypeName));


            var totalMakes = query.Count();

            // If no data exists, stop here
            if (totalMakes == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Vehicles List:");
            Console.WriteLine("--------------");

            Console.WriteLine(
                                $"Total Makes: {totalMakes},"
                            );
        }


        //problem 6
        public static void GetTotalVehiclesPerMakeAndDriveTypeName(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 6 : Get total vehicles per DriveTypeName Per Make and order them per make asc then per total Desc--");
            Console.WriteLine("Solution of Problem 6--");

            var query = context.VehicleMasterDetails
                .GroupBy(vehicle => new {vehicle.Make, vehicle.DriveTypeName})
                .Select(group => new
                {
                    make = group.Key.Make,
                    driveTypeName = group.Key.DriveTypeName,
                    totalVehicles = group.Count()

                })
                .OrderBy(result => result.make)
                .ThenByDescending(result => result.totalVehicles)
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
                Console.WriteLine(
                    $"Make: {item.make}, " +
                    $"Drive Type Name: {item.driveTypeName}, " +
                    $"Total Vehicles: {item.totalVehicles}");
            }
        }
    }
}
