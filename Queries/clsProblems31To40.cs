using EF_Practice_1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practice_1.Queries
{
    internal class clsProblems31To40
    {
        //Problem 1
        public static void GetMinMaxAvgOfEngineCc(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 1 : Get Minimum Engine CC , Maximum Engine CC , and Average Engine CC of all Vehicles\r\n--");
            Console.WriteLine("Solution of Problem 1--");

            var query = context.VehicleDetails
                .GroupBy(vehicles => 1)
                .Select(group => new
                {
                    MinEngineCC = group.Min(vehicle => vehicle.EngineCc),
                    MaxEngineCC = group.Max(vehicle => vehicle.EngineCc),
                    AvgEngineCC = group.Average(vehicle => vehicle.EngineCc),
                }
                    
                
                );


            var vehicles = query.AsNoTracking().FirstOrDefault();

            // If no data exists, stop here
            if (vehicles == null)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            Console.WriteLine(
                $"Min Engine CC: {vehicles.MinEngineCC}," +
                   $"Max Engine CC: {vehicles.MaxEngineCC}, " +
                   $"Avg Engine CC : {vehicles.AvgEngineCC}, "
                );
        }

        //Problem 2
        public static void GetAllVehiclesThatHaveMinimumEngineCC(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 2 : Get all vehicles that have the minimum Engine_CC\r\n--");
            Console.WriteLine("Solution of Problem 2--");

            var query = context.VehicleDetails
                .Where(vehicle => vehicle.EngineCc == context.VehicleDetails.Min(v2 => v2.EngineCc))
                .Select(result =>new
                {
                    VehicleDisplayName = result.VehicleDisplayName
                });


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach(var item in vehicles)
            {
                Console.WriteLine(
                    $"Vehicle Display Name: {item.VehicleDisplayName},"
                );
            }
            
        }

        //Problem 3
        public static void GetAllVehiclesThatHaveMaximumEngineCC(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 3 : Get all vehicles that have the maximum Engine_CC\r\n--");
            Console.WriteLine("Solution of Problem 3--");

            var query = context.VehicleDetails
                .Where(vehicle => vehicle.EngineCc == context.VehicleDetails.Max(v2 => v2.EngineCc))
                .Select(result => new
                {
                    VehicleDisplayName = result.VehicleDisplayName
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

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Vehicle Display Name: {item.VehicleDisplayName},"
                );
            }

        }

        //Problem 4
        public static void GetAllVehiclesThatHaveEngineCCBelowAverage(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 4 : Get all vehicles that have Engin_CC below average\r\n--");
            Console.WriteLine("Solution of Problem 4--");

            var query = context.VehicleDetails
                .Where(vehicle => vehicle.EngineCc < context.VehicleDetails.Average(v2 => v2.EngineCc))
                .Select(result => new
                {
                    VehicleDisplayName = result.VehicleDisplayName
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

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Vehicle Display Name: {item.VehicleDisplayName},"
                );
            }

        }

        //Problem 5
        public static void GetTotalVehiclesThatHaveEngineCCAboveAverage(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 5 : Get total vehicles that have Engin_CC above average\r\n--");
            Console.WriteLine("Solution of Problem 5--");

            var query = context.VehicleDetails
                .Where(vehicle => vehicle.EngineCc > context.VehicleDetails.Average(v2 => v2.EngineCc));


            var vehicles = query.Count();

            // If no data exists, stop here
            if (vehicles == 0)
            {
                Console.WriteLine("No vehicles found in the database.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            Console.WriteLine(
                    $"Total Vehicules: {vehicles},"
                );

        }


        //Problem 6
        public static void GetAllUniqueEnginCCAndSortThemDesc(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 6 : Get all unique Engin_CC and sort them Desc\r\n--");
            Console.WriteLine("Solution of Problem 6--");

            var query = context.VehicleDetails
                .Select(vehicle => new
                {
                    EngineCc = vehicle.EngineCc,
                })
                .Distinct()
                .OrderByDescending(result => result.EngineCc)
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
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
                    $"Engine CC: {item.EngineCc},"
                );
            }

        }

        //Problem 7
        public static void GetTheMaximumEngineCCByNumber(VehicleMakesDbContext context, int number)
        {
            Console.WriteLine("Problem 7 : Get the maximum 'number you want' Engine CC\r\n--");
            Console.WriteLine("Solution of Problem 7--");

            var query = context.VehicleDetails
                .Select(vehicle => new
                {
                    EngineCc = vehicle.EngineCc,
                })
                .Distinct()
                .OrderByDescending(result => result.EngineCc)
                .Take(number);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
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
                    $"Engine CC: {item.EngineCc},"
                );
            }

        }

        //Problem 8
        public static void GetAllVehiclesHasOneOfTheMaxNumberEnginCC(VehicleMakesDbContext context, int number)
        {
            Console.WriteLine("Problem 8 : Get all vehicles that has one of the Max 'number you want' Engine CC\r\n--");
            Console.WriteLine("Solution of Problem 8--");

            var query = context.VehicleDetails
                .Where(vehicle => context.VehicleDetails
                    .Select(v2 => v2.EngineCc)
                    .Distinct()
                    .OrderByDescending(engineCc => engineCc)
                    .Take(number)
                    .Contains(vehicle.EngineCc)
                )
                .Select(v => new
                {
                    VehicleDisplayName = v.VehicleDisplayName,
                    EngineCc = v.EngineCc
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

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Vehicle Display Name: {item.VehicleDisplayName}," +
                    $"Engine CC: {item.EngineCc},"
                );
            }

        }

        //Problem 9
        public static void GetAllMakesThatManufacturesHasOneOfTheMaxNumberEnginCC(VehicleMakesDbContext context, int number)
        {
            Console.WriteLine("Problem 9 : Get all Makes That Manufactures one of the Max 'number you want' Engine CC\r\n--");
            Console.WriteLine("Solution of Problem 9--");

            var query = context.VehicleDetails
                .Join(context.Makes,
                    vehicleDetails => vehicleDetails.MakeId,
                    makes => makes.MakeId,
                    (vehicleDetails, makes) => new {
                        makes.MakeName,
                        vehicleDetails.VehicleDisplayName,
                        vehicleDetails.EngineCc,
                    })
                .Where(vehicle => context.VehicleDetails
                    .Select(v2 => v2.EngineCc)
                    .Distinct()
                    .OrderByDescending(engineCc => engineCc)
                    .Take(number)
                    .Contains(vehicle.EngineCc)
                )
                .Select(result => new
                {
                    make = result.MakeName,
                    VehicleDisplayName = result.VehicleDisplayName,
                    EngineCc = result.EngineCc
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

            Console.WriteLine("Results:");
            Console.WriteLine("--------------");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"Make: {item.make}," +
                    $"Vehicle Display Name: {item.VehicleDisplayName}," +
                    $"Engine CC: {item.EngineCc},"
                );
            }

        }

        //Problem 10
        public static void GetATableOfUniqueEngineCCAndCalculateTaxPerEngineCC(VehicleMakesDbContext context)
        {
            Console.WriteLine("Problem 10 : Get a table of unique Engine_CC and calculate tax per Engine CC\r\n--");
            Console.WriteLine("Solution of Problem 10--");

            var query = context.VehicleDetails
                .Select(result => new
                {
                    EngineCc = result.EngineCc,
                    Tax = result.EngineCc >= 0 && result.EngineCc <= 1000 ? 100 : 
                        result.EngineCc >= 1001 && result.EngineCc <= 2000 ? 200 :
                        result.EngineCc >= 2001 && result.EngineCc <= 4000 ? 300 :
                        result.EngineCc >= 4001 && result.EngineCc <= 6000 ? 400 :
                        result.EngineCc >= 6001 && result.EngineCc <= 8000 ? 500 :
                        result.EngineCc > 8000 ? 600 : 0
                    })
                .Distinct()
                .Take(20);


            var vehicles = query.AsNoTracking().ToList();

            // If no data exists, stop here
            if (vehicles.Count == 0)
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
                    $"Engine CC: {item.EngineCc}," +
                     $"Tax: {item.Tax},"
                );
            }

        }

    }
}
