using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingServiceAPI.Common;

namespace ParkingServiceAPI.DataContract
{
    public class ParkingFeesCalculator : IParkingFeesCalculator
    {
        private readonly IConfigurationRepository _configurationRepository;
        public ParkingFeesCalculator(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public decimal CalculateFees(double hours)
        {
            decimal rate = 0;
            decimal amountTillDate = 0;

            var multiplier = (int)(hours / 24);
            if (multiplier > 0)
            {
                var dailyCharges = _configurationRepository.Get("PerDayCharges");
                amountTillDate = multiplier * Convert.ToDecimal(dailyCharges);
            }

            var remainder = hours % 24;

            var t = _configurationRepository.Get("PerHourCharges")
                .Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            var hourlyRatesDictionary =
                t.ToDictionary(s => s.Split(':')[0], s => s.Split(':')[1]);

            foreach (var item in hourlyRatesDictionary)
            {
                var split = item.Key.Split('-');
                var min = split[0];
                var max = split[1];

                if (remainder >= Convert.ToDouble(min) && remainder <= Convert.ToDouble(max))
                {
                    rate = Convert.ToDecimal(item.Value);
                    break;
                }

            }

            return amountTillDate + rate;
        }

    }
}
