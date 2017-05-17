using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ParkingServiceAPI.Common;
using ParkingServiceAPI.DataAccess;
using ParkingServiceAPI.FaultContract.DataContract;
using ParkingServiceAPI.FaultContract.FaultContract;

namespace ParkingServiceAPI.DataContract
{
    public class ParkingServiceImplementation : IParkingServiceImplementation
    {
        private readonly IParkingServiceUtilities _parkingServiceUtilities;
        private readonly IParkingFeesCalculator _parkingFeesCalculator;
        private readonly IParkingServiceDatabaseAccess _parkingServiceDataAccess;

        public ParkingServiceImplementation(IParkingServiceUtilities parkingServiceUtilities,
                                            IParkingFeesCalculator parkingFeesCalculator,
                                            IParkingServiceDatabaseAccess parkingServiceDataAccess)
        {
            _parkingServiceUtilities = parkingServiceUtilities;
            _parkingFeesCalculator = parkingFeesCalculator;
            _parkingServiceDataAccess = parkingServiceDataAccess;
        }

        /// <summary>
        /// Get Available spaces in a parking lot using the LotId
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public LotInformation GetLotAvailability(string lotId)
        {
            // if a format query string parameter has been specified, set the response format to that. If no such  
            // query string parameter exists the Accept header will be used  
            _parkingServiceUtilities.FormatParkingServiceResponse();

            var lotInformation = _parkingServiceDataAccess.GetLotInfoFromDb(lotId);

            if (lotInformation == null)
                throw new FaultException<ServiceFault>(
                    new ServiceFault() { Message = "Lot does not exist. InvalidLotId=)" + lotId });

            return lotInformation;
        }

        /// <summary>
        /// Get Available spaces in a parking lot using the LotId
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public VehicleInformation GetVehicleInformation(string vehicleId)
        {
            // if a format query string parameter has been specified, set the response format to that. If no such  
            // query string parameter exists the Accept header will be used  
            _parkingServiceUtilities.FormatParkingServiceResponse();

            var vehicleInformation = _parkingServiceDataAccess.GetVehicleInfoFromDb(vehicleId);

            if (vehicleInformation == null)
                throw new FaultException<ServiceFault>(
                    new ServiceFault() { Message = "Vehicle does not exist. VehicleId=)" + vehicleId });
                    
            if (vehicleInformation.CheckOutTime == null)
                vehicleInformation.CheckOutTime = DateTime.Now;

            var parkingHours = (vehicleInformation.CheckOutTime.Value - vehicleInformation.CheckInTime).TotalHours;

            vehicleInformation.OutstandingAmount = _parkingFeesCalculator.CalculateFees(parkingHours);

            return vehicleInformation;
        }


    }
}
