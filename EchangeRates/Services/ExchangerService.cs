using EchangeRates.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EchangeRates.Services
{
    public class ExchangerService: IExchangerService
    {
        /// <summary>
        /// Service URL
        /// </summary>
        private string Url { get; set; }
        /// <summary>
        /// HttpClient 
        /// </summary>
        private HttpClient Client { get; }

        public ExchangerService(string url)
        {
            Url = url;
            Client = new HttpClient();
        }
        /// <summary>
        /// Method to create desired output and check for exceptions
        /// </summary>
        /// <param name="dates"></param>
        /// <param name="baseCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        public async Task<RatesResult> GetRates(string dates, string baseCurrency, string targetCurrency) {

            List<SingleRate> rates = null;

            try
            {
                rates = await Query(dates, baseCurrency, targetCurrency);
            }
            catch (Exception e) {
                return new RatesResult() { Error = e.Message };
            }

            var result = RatesResult.Create(
                                        rates.OrderBy(x=>x.Rates[targetCurrency]).First(),
                                        rates.OrderByDescending(x => x.Rates[targetCurrency]).First(),
                                        rates.Average(x => x.Rates[targetCurrency])
                                        );
            return result;
        }
        /// <summary>
        /// Method that queries the api
        /// </summary>
        /// <param name="dates">List of dates</param>
        /// <param name="baseCurrency">Base currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <returns><seealso cref="<List<SingleRate>"/></returns>
        private async Task<List<SingleRate>> Query(string dates, string baseCurrency, string targetCurrency) {

            string[] datesArray = dates.Split(",");
            var results = new List<SingleRate>();

            foreach (var date in datesArray)
            {
                var path = $"{Url}/{date}?base={baseCurrency}&symbols={targetCurrency}";
                var response = await Client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<SingleRate>();
                    results.Add(res);
                }

                else
                {
                    throw new Exception("Error occurred during service call!");
                }
            }

            return results;
        }
    }
}
