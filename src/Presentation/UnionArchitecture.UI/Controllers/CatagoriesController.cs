using Microsoft.AspNetCore.Mvc;

namespace UnionArchitecture.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoriesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Salam";
        }
    }
}
