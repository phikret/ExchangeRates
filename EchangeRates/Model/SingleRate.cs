using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchangeRates.Model
{
    public class SingleRate
    {
        /// <summary>
        /// Date of the rate
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Rates dictionary
        /// </summary>
        public Dictionary<string,float> Rates { get; set; }
        /// <summary>
        /// Base currency
        /// </summary>
        public string Base { get; set; }

    }
}
