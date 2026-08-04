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
    }
}
