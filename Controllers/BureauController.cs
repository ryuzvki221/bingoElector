using bingoElector.Models;
using bingoElector.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bingoElector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BureauController : ControllerBase
    {
        private readonly BureauService _bureauService = null!;

        public BureauController(BureauService bureauService)
        {
            _bureauService = bureauService;
        }
        //Get: api/Bureaux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bureau>>> Get()
        {
            var result = await _bureauService.GetBureaux();
            return Ok(result);
        }
 
    }
}
