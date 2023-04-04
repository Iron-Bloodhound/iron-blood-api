using Microsoft.AspNetCore.Mvc;
using ironblood.Domain.Catalog;

namespace ironblood.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok("hellow world.");
        }
        }
    
}