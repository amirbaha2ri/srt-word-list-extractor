using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SrtWordListExtractor.Controllers
{
    /// <summary>
    /// Returnt the version
    /// </summary>
    [Route("api/[controller]")]
    [Description("Returnt the version")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("0.00");
        }
    }
}
