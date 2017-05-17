using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServiceAPI.FaultContract.FaultContract
{
    [DataContract]
    public partial class ServiceFault
    {
        /// <remarks>Message to indicate a system problem</remarks>
        [DataMember]
        public string Message { get; set; }
    }
}
