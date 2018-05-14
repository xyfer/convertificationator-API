using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using convertificationatorAPI.Model;
using convertificationatorAPI.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace convertificationator_API.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        ForexAPIService _apiService = new ForexAPIService();

        [HttpGet("{baseCurrency}/{targetCurrency}")]
        public JsonResult Get(string baseCurrency, string targetCurrency)
        {
            ForexRequest req = new ForexRequest { BaseCurrency = baseCurrency, TargetCurrency = targetCurrency };
            string response = _apiService.getForex(req);
            return Json(response);
        }
    }
}
