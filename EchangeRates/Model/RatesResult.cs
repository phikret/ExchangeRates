using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchangeRates.Model
{
    /// <summary>
    /// Rate model to return
    /// </summary>
    public class RateDto {
        public string Date { get; set; }
        public string Currency { get; set; }
        public float Rate { get; set; }

        internal static RateDto CreateFromKeyValuePair(KeyValuePair<string, Dictionary<string, float>> keyValuePair)
        {
            return new RateDto { Date = keyValuePair.Key, Currency = keyValuePair.Value.Select(x=>x.Key).FirstOrDefault(), Rate = keyValuePair.Value.Select(x=>x.Value).FirstOrDefault() };
        }
    }
    public class RatesResult
    {
        /// <summary>
        /// Minimum rate at date
        /// </summary>
        public RateDto Min { get; set; }
        /// <summary>
        /// The maximum rate at date
        /// </summary>
        public RateDto Max { get; set; }
        /// <summary>
        /// Average rate for the selected period
        /// </summary>
        public double Avg { get; set; }
        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// Create result
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="average"></param>
        /// <returns></returns>
        public static RatesResult Create(RateDto min, RateDto max, double average)
        {
            return new RatesResult() { Min = min, Max = max, Avg = average, Error = string.Empty };
        }
    }
}
