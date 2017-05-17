using System.Collections.Specialized;

namespace ParkingServiceAPI.Common
{
    public interface IConfigurationRepository
    {
        NameValueCollection DynamicSettings { get; }
        string Get(string key);
    }
}