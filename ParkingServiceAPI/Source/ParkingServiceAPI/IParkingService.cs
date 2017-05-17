using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ParkingServiceAPI.FaultContract.DataContract;

namespace ParkingServiceAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IParkingService" in both code and config file together.
    [ServiceContract]
    public interface IParkingService
    {
        /// <summary>
        /// Get Available spaces in a parking lot using the LotId
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "lot/{lotId}")]
        LotInformation GetLotAvailability(string lotId);


        /// <summary>
        /// Get VehicleInformation
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "vehicle/{vehicleId}")]
        VehicleInformation GetVehicleInformation(string vehicleId);

    }
}
