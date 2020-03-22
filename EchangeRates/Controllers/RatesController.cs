using EchangeRates.Model;
using EchangeRates.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EchangeRates.Controllers
{
    /// <summary>
    /// Controller for retrieving rates
    /// </summary>
    [Route("api/v1")]
    public class RatesController : Controller
    {
        /// <summary>
        /// Exchanger service
        /// </summary>
        private readonly IExchangerService ExchangerService;
        /// <summary>
        /// Exchanger service to be injected by DI
        /// </summary>
        /// <param name="exchangerService"></param>
        public RatesController(IExchangerService exchangerService)
        {
            ExchangerService = exchangerService;
        }
        /// <summary>
        /// Returns the exchange data 
        /// </summary>
        /// <returns></returns>
        [HttpGet("rates")]
        public async Task<IActionResult> Rates([FromQuery]string dates, [FromQuery]string @base, [FromQuery]string target)
        {

            var res = await ExchangerService.GetRates(dates, @base, target);

            if (!string.IsNullOrEmpty(res.Error))
            {
                return BadRequest(res.Error);
            }

            return Ok(res);
        }
    }
}
