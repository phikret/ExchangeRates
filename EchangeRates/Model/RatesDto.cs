using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchangeRates.Model
{
    /// <summary>
    /// Rates as returned from API json
    /// </summary>
    public class RatesDto
    {
        /// <summary>
        /// Rates dictionary
        /// </summary>
        public Dictionary<string, Dictionary<string,float>> Rates { get; set; }
        /// <summary>
        /// Base currency
        /// </summary>
        public string Base { get; set; }
        /// <summary>
        /// Starting date
        /// </summary>
        public string Start_at { get; set; }
        /// <summary>
        /// Ending date
        /// </summary>
        public string End_at { get; set; }

    }
}
