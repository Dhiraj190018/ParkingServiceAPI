using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServiceAPI.Common
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public ConfigurationRepository()
        {
            DynamicSettings = ConfigurationManager.AppSettings;
        }

        public NameValueCollection DynamicSettings { get; private set; }

        public string Get(string key)
        {
            string value;
            try
            {
                value = DynamicSettings.Get(key);
            }
            catch (Exception ex)
            {
            throw new Exception("Error while fetching value for Key=" + key + " from ConfigurationFile " + ex.Message);
            }
            return value;
        }
    }
}
