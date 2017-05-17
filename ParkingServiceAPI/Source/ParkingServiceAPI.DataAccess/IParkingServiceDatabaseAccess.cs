using ParkingServiceAPI.FaultContract.DataContract;

namespace ParkingServiceAPI.DataAccess
{
    public interface IParkingServiceDatabaseAccess
    {
        LotInformation GetLotInfoFromDb(string lotId);
        VehicleInformation GetVehicleInfoFromDb(string vehicleId);
    }
}