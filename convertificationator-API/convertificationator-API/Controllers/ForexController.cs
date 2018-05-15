using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using convertificationatorAPI.Model;
using convertificationatorAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace convertificationator_API.Controllers
{
    [Route("api/[controller]")]
    public class ForexController : Controller
    {
        private IConfiguration configuration;
        private ForexAPIService apiService;
        private String apiKey; 

        public ForexController(IConfiguration Configuration)
        {
            configuration = Configuration;
            apiKey = configuration.GetValue<String>("apiKey");
            apiService = new ForexAPIService();
        }

        [HttpGet("{baseCurrency}/{targetCurrency}")]
        public IActionResult Get(string baseCurrency, string targetCurrency)
        {
            ForexRequest req = new ForexRequest { BaseCurrency = baseCurrency, TargetCurrency = targetCurrency };
            string response = apiService.getForex(req, apiKey);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
