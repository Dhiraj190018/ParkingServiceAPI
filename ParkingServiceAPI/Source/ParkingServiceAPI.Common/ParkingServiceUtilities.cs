using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServiceAPI.Common
{
    public class ParkingServiceUtilities : IParkingServiceUtilities
    {
        public void FormatParkingServiceResponse()
        {
            if (WebOperationContext.Current != null)
            {
                var formatQueryStringValue =
                    WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
                if (!string.IsNullOrEmpty(formatQueryStringValue))
                {
                    if (formatQueryStringValue.Equals("json", StringComparison.OrdinalIgnoreCase))
                        WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
                    else
                        WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
                }
            }
        }
    }
}
