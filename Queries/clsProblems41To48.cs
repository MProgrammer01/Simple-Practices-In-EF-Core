using EF_Practice_1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice_1.Queries
{
    internal class clsProblems41To48
    {
        //Problem 1
        public static void GetMakeAndTotalDoorsPerMake(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 1 : Get Make and Total Number Of Doors Manufactured Per Make\r\n--");
            Console.WriteLine("Solution of Problem 1--");

            var query = context.VehicleDetails
                .Join(context.Makes,
                    vehicleDetails => vehicleDetails.MakeId,
                    makes => makes.MakeId,
                    (vehicleDetails, makes) => new {
                        makes.MakeName,
                        vehicleDetails.NumDoors
                    }
                )
                .GroupBy(make => make.MakeName)
                .Select(group => new
                {
                    MakeName = group.Key,
                    Total = group.Sum(vehicle => vehicle.NumDoors),
                    
                }


                )
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles == null)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"MakeName: {item.MakeName}," +
                     $"Total: {item.Total},"
                );
            }
        }

        //Problem 2
        public static void GetMakeAndTotalDoorsPerMake(VehicleMakesDbContext context, string makeName)
        {
            Console.WriteLine("Problem 2 : Get Total Number Of Doors Manufactured by 'name of make'\r\n--");
            Console.WriteLine("Solution of Problem 2--");

            var query = context.VehicleDetails
                .Join(context.Makes,
                    vehicleDetails => vehicleDetails.MakeId,
                    makes => makes.MakeId,
                    (vehicleDetails, makes) => new {
                        makes.MakeName,
                        vehicleDetails.NumDoors
                    }
                )
                .GroupBy(make => make.MakeName)
                .Where(group => group.Key.Contains(makeName))
                .Select(result => new
                {
                    MakeName = result.Key,
                    Total = result.Sum(vehicle => vehicle.NumDoors),

                });


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles == null)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"MakeName: {item.MakeName}," +
                     $"Total: {item.Total},"
                );
            }
        }

        //Problem 3
        public static void GetNumberOfModelsPerMake(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 3 : Get Number of Models Per Make\r\n--");
            Console.WriteLine("Solution of Problem 3--");

            var query = context.Makes
                 .Select(make => new
                 {
                     Make = make.MakeName,
                     NumberOfModels = make.MakeModels.Count()
                 })
                 .OrderByDescending(x => x.NumberOfModels)
                 .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles == null)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Make: {item.Make}," +
                     $"Number Of Models: {item.NumberOfModels},"
                );
            }
        }

        //Problem 4
        public static void GetHighestManufacturersMakeHighestNumberOfModels(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 4 : Get the highest 3 manufacturers that make the highest number of models\r\n--");
            Console.WriteLine("Solution of Problem 4--");

            var query = context.Makes
                 .Select(make => new
                 {
                     Make = make.MakeName,
                     NumberOfModels = make.MakeModels.Count()
                 })
                 .OrderByDescending(x => x.NumberOfModels)
                 .Take(3);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles == null)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Make: {item.Make}," +
                     $"Number Of Models: {item.NumberOfModels},"
                );
            }
        }

        //Problem 5
        public static void GetTheHighestNumberOfModelsManufactured(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 5 : Get the highest number of models manufactured\r\n--");
            Console.WriteLine("Solution of Problem 5--");

            var maxNumberOfModels = context.Makes
                 .Select(make => make.MakeModels.Count())
                 .Max();


            // If no data exists, stop here
            if (maxNumberOfModels == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            Console.WriteLine(
                    $"max Number Of Models: {maxNumberOfModels},"
                );
        }

        //Problem 6
        public static void GetTheHighestManufacturersManufacturedHighestModelsNumber(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 6 : Get the highest Manufacturers manufactured the highest number of models\r\n--");
            Console.WriteLine("Solution of Problem 6--");

            var query = context.Makes
                 .Select(make => new
                 {
                     Make = make.MakeName,
                     NumberOfModels = make.MakeModels.Count()
                 })
                 .Where(make => context.Makes
                    .Select(make => make.MakeModels.Count()).Max() == make.NumberOfModels
                 );


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles == null)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Make: {item.Make}," +
                     $"Number Of Models: {item.NumberOfModels},"
                );
            }
        }

        //Problem 7
        public static void GetTheLowestManufacturersManufacturedLowestModelsNumber(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 7 : Get the Lowest Manufacturers manufactured the lowest number of models\r\n--");
            Console.WriteLine("Solution of Problem 7--");

            var query = context.Makes
                 .Select(make => new
                 {
                     Make = make.MakeName,
                     NumberOfModels = make.MakeModels.Count()
                 })
                 .Where(make => context.Makes
                    .Select(make => make.MakeModels.Count()).Min() == make.NumberOfModels
                 );


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles == null)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Make: {item.Make}," +
                     $"Number Of Models: {item.NumberOfModels},"
                );
            }
        }

        //Problem 8
        public static void GetAllFuelTypesResultShowedInRandomOrder(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 8 : Get all Fuel Types , each time the result should be showed in random order\r\n--");
            Console.WriteLine("Solution of Problem 8--");

            var query = context.FuelTypes
                .OrderBy(x => Guid.NewGuid())
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles == null)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Make: {item.FuelTypeId}," +
                     $"Number Of Models: {item.FuelTypeName},"
                );
            }
        }
    }
}
