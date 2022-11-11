using bingoElector.Models;
using bingoElector.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bingoElector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentreController : ControllerBase
    {
        private readonly CentreService _centreService = null!;

        public CentreController(CentreService centreService)
        {
            _centreService = centreService;
        }
        // GET: api/Centre 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Centre>>> Get()
        {
            var result = await _centreService.GetCentres();
            return Ok(result);
        }



    }
}
