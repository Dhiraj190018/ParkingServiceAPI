using ParkingServiceAPI.FaultContract.DataContract;

namespace ParkingServiceAPI.DataContract
{
    public interface IParkingServiceImplementation
    {
        /// <summary>
        /// Get Available spaces in a parking lot using the LotId
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        LotInformation GetLotAvailability(string lotId);


        /// <summary>
        /// Get VehicleInformation
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        VehicleInformation GetVehicleInformation(string vehicleId);
    }
}