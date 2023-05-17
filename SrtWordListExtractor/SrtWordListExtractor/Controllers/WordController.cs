using Microsoft.AspNetCore.Mvc;
using SWE.Service.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SrtWordListExtractor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<WordDto> Get(int id)
        {
            var word = new WordDto()
            {
                ID = id,
                Name = "its working"
            };
            return Ok(word);
        }
    }
}
