using EF_Practice_1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice_1.Queries
{
    internal class clsProblems21To30
    {
        //Problem 1
        public static void GetVehiclesThatHaveSubModelName(VehicleMakesDbContext context, string subModelName)
        {
            Console.WriteLine("Problem 1 : Get MakeID , Make, SubModelName for all vehicles that have SubModelName 'Elite'\r\n--");
            Console.WriteLine("Solution of Problem 1--");

            var query = context.VehicleDetails
                .Join(context.Makes,
                    vehicleDetails => vehicleDetails.MakeId,
                    makes => makes.MakeId,
                    (vehicleDetails, makes) => new {
                        makes.MakeId,
                        makes.MakeName,
                        vehicleDetails.SubModelId
                    })
                .Join(context.SubModels,
                    resultOfFirstJoin => resultOfFirstJoin.SubModelId,
                    subModels => subModels.SubModelId,
                    (resultOfFirstJoin, subModels) => new
                    {
                        resultOfFirstJoin.MakeId,
                        resultOfFirstJoin.MakeName,
                        subModels.SubModelName
                    })
                .Where(subModels => subModels.SubModelName.Equals(subModelName))
                .Distinct();


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
                Console.WriteLine($"Make: {item.MakeId}," +
                    $" Number Of Fields: {item.MakeName}, " +
                    $"total Vehicules : {item.SubModelName}, "
                 );
            }
        }

        //Problem 2
        public static void GetAllVehiclesThatHaveEnginesAndDoorsMoreThan(VehicleMakesDbContext context, decimal engine, int doors)
        {
            Console.WriteLine("Problem 2 : Get all vehicles that have Engines > 'number' Liters and have only 'number' doors\r\n--");
            Console.WriteLine("Solution of Problem 2--");

            var query = context.VehicleDetails
                .Where(vehicle => vehicle.EngineLiterDisplay > engine && vehicle.NumDoors > doors )
                .Select(results => new
                {
                    name = results.VehicleDisplayName,
                    engine = results.EngineLiterDisplay,
                    doors = results.NumDoors
                })
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
                Console.WriteLine($"Vehicle Name: {item.name}," +
                    $"Engine Liter Display: {item.engine}, " +
                    $"Num Doors: {item.doors}, "
                 );
            }
        }

        //Problem 3
        public static void GetMakeAndVehiclesThatHaveEnginesContainAndHaveCylindersNumber(VehicleMakesDbContext context, string engineLetter, int numberCylinder)
        {
            Console.WriteLine("Problem 3 : Get make and vehicles that the engine contains 'letter' and have Cylinders = 'number'\r\n\r\n--");
            Console.WriteLine("Solution of Problem 3--");

            var query = context.VehicleDetails
                .Join(context.Makes,
                    vehicleDetails => vehicleDetails.MakeId,
                    makes => makes.MakeId,
                    (vehicleDetails, makes) => new {
                        makes.MakeName,
                        vehicleDetails.Engine,
                        vehicleDetails.EngineCylinders,
                        vehicleDetails.VehicleDisplayName,
                    })
                .Where(vehicle => vehicle.Engine!.Contains(engineLetter) && vehicle.EngineCylinders == numberCylinder)
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
                    $"Make Name: {item.MakeName}," +
                    $"Vehicle Display Name: {item.VehicleDisplayName}," +
                    $"Engine: {item.Engine}, " +
                    $"Engine Cylinders: {item.EngineCylinders}, "
                 );
            }
        }
    }
}
