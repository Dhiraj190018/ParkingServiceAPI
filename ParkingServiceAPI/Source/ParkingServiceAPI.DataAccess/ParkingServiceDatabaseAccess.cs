using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ParkingServiceAPI.FaultContract.DataContract;

namespace ParkingServiceAPI.DataAccess
{
    public class ParkingServiceDatabaseAccess : IParkingServiceDatabaseAccess
    {
        public LotInformation GetLotInfoFromDb(string lotId)
        {
            // ToDo : Make Database calls for getting the LotInfo 

            // Stubbed response
            return new LotInformation() { LotId = lotId, LotName = "BeavertonCityParking", TotalSpace = "1000", CurrentAvailability = "34" };
        }

        public VehicleInformation GetVehicleInfoFromDb(string vehicleId)
        {
            // ToDo : Make Database calls for getting the LotInfo 


            // Stubbed response
            var checkInTime = vehicleId.Length == 5 ? DateTime.Now.AddHours(-2.5) : DateTime.Now.AddHours(-3.5);
            var number = RandomNumberGenerator.Create().ToString();
            return new VehicleInformation() { VehicleId = vehicleId, VinNumber = number, VehicleName = "Tesla Model S - VIN-", CheckInTime = checkInTime , CheckOutTime = null};
        }
    }
}
