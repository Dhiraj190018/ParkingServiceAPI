using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ParkingServiceAPI.DataContract;
using ParkingServiceAPI.FaultContract.DataContract;

namespace ParkingServiceAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ParkingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ParkingService.svc or ParkingService.svc.cs at the Solution Explorer and start debugging.
    public class ParkingService : IParkingService
    {
        public readonly IParkingServiceImplementation ParkingServiceImplementation;
        
        public ParkingService(IParkingServiceImplementation parkingServiceImplementation)
        {
            ParkingServiceImplementation = parkingServiceImplementation;
        }
       
        public LotInformation GetLotAvailability(string lotId)
        {
            return ParkingServiceImplementation.GetLotAvailability(lotId);
        }

        public VehicleInformation GetVehicleInformation(string vehicleId)
        {
            return ParkingServiceImplementation.GetVehicleInformation(vehicleId);
        }
    }
}
