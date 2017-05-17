using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServiceAPI.FaultContract.DataContract
{
    [DataContract]
    public class LotInformation
    {
        [DataMember]
        public string LotId { get; set; }

        [DataMember]
        public string LotName { get; set; }

        [DataMember]
        public string CurrentAvailability { get; set; }

        [DataMember]
        public string TotalSpace { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }

    }
}
