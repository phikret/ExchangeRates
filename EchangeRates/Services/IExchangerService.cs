using EchangeRates.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchangeRates.Services
{
    public interface IExchangerService
    {
        /// <summary>
        /// Method that is used to format result recieved by calling Query method
        /// </summary>
        /// <param name="dates"></param>
        /// <param name="baseCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        Task<RatesResult> GetRates(string dates, string baseCurrency, string targetCurrency);
        
    }
}
