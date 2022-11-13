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
            var result = await _centreService.GetAllCentres();
            return Ok(result);
        }

        // POST: api/Centre
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Centre centre)
        {
            await _centreService.AddCentre(centre);
            return Ok();
        }

        
        // PUT: api/Centre/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] string name, string address, int nombredesalle, List<Bureau>)
        {
            var elector = await _centreService.GetCentre(id);
            if (centre == null)
            {
                return NotFound();
            }
            await _centreService.UpdateCentre(id,name, address, nombredesalle, Bureau);
            return Ok();
        }

        // DELETE: api/Elector/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var centre = await _centreService.GetCentre(id);
            if (centre == null)
            {
                return NotFound();
            }
            await _centreService.RemoveCentre(id);
            return Ok();
        }

        // DELETE: api/Electors
        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            await _centreService.RemoveAllCentres();
            return Ok();
        }

    }
}
