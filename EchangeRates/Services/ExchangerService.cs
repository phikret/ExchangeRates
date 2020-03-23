using EchangeRates.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EchangeRates.Services
{
    public class ExchangerService : IExchangerService
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
        public async Task<RatesResult> GetRates(string dates, string baseCurrency, string targetCurrency)
        {
            try
            {
                var rates = await Query(dates, baseCurrency, targetCurrency);
                var minRate = RateDto.CreateFromKeyValuePair(rates.OrderBy(x => x.Value.GetValueOrDefault(targetCurrency)).Select(x => x).FirstOrDefault());
                var maxRate = RateDto.CreateFromKeyValuePair(rates.OrderByDescending(x => x.Value.GetValueOrDefault(targetCurrency)).Select(x => x).FirstOrDefault());
                var result = RatesResult.Create(minRate,
                                        maxRate,
                                        rates.Average(x => x.Value.GetValueOrDefault(targetCurrency))
                                        );
                return result;
            }
            catch (Exception e)
            {
                return new RatesResult() { Error = e.Message };
            }
        }
        /// <summary>
        /// Method that queries the api
        /// </summary>
        /// <param name="dates">List of dates</param>
        /// <param name="baseCurrency">Base currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <returns><seealso cref="<List<SingleRate>"/></returns>
        private async Task<List<KeyValuePair<string,Dictionary<string,float>>>> Query(string dates, string baseCurrency, string targetCurrency)
        {

            string[] datesArray = dates.Split(",");
            List<DateTime> datesList = new List<DateTime>();

            foreach (var date in datesArray)
            {
                //This conversion is needed to be able to properly sort dates
                datesList.Add(DateTime.Parse(date));
            }

            var minDate = datesList.Min();
            var maxDate = datesList.Max();

            //I could not find another endpoint that I could provide with the list of dates make a single call.
            //Therefore I decided to use this endpoint instead and then filter the result against the list of provided dates
            var path = $"{Url}/history?start_at={minDate:yyyy-MM-dd}&end_at={maxDate:yyyy-MM-dd}&base={baseCurrency}&symbols={targetCurrency}";

            var response = await Client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                //Calling the API 
                var res = await response.Content.ReadAsAsync<RatesDto>();
                //Filtering dates. Only dates from the provided list should be part of the result. Note that 
                //API may not return any result for some date(s)
                var filteredResult = res.Rates.Where(x => datesArray.Contains(x.Key)).Select(x => x).ToList();
                
                return filteredResult;
            }
            else
            {
                throw new Exception("Error occurred during service call!");
            }
        }
    }
}
