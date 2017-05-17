using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServiceAPI.FaultContract.DataContract
{
    [DataContract]
    public class VehicleInformation
    {
        [DataMember]
        public string VehicleId { get; set; }

        [DataMember]
        public string VinNumber { get; set; }

        [DataMember]
        public string VehicleName { get; set; }

        [DataMember]
        public DateTime CheckInTime { get; set; }

        [DataMember]
        public DateTime? CheckOutTime { get; set; }

        [DataMember]
        public decimal OutstandingAmount { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }

    }
}
