using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        // GET api/currencies
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "usd", "eur", "bgn" };
        }
    }
}
