using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchangeRates.Model
{
    public class RatesResult
    {
        /// <summary>
        /// Minimum rate at date
        /// </summary>
        public SingleRate Min { get; set; }
        /// <summary>
        /// The maximum rate at date
        /// </summary>
        public SingleRate Max { get; set; }
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
        public static RatesResult Create(SingleRate min, SingleRate max, double average)
        {
            return new RatesResult() { Min = min, Max = max, Avg = average, Error = string.Empty };
        }
    }
}
