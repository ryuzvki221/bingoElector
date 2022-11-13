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
        private readonly BureauService _bureauService;

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

        // GET: api/Bureau/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Bureau>> Get(string id)
        {
            var bureau = await _bureauService.GetBureau(id);
            if (bureau == null)
            {
                return NotFound();
            }
            return Ok(bureau);
        }

        // POST: api/Bureau
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Bureau bureau)
        {
            await _bureauService.AddBureau(bureau);
            return Ok();
        }

        // PUT: api/Elector/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] string name, int capacite)
        {
            var elector = await _bureauService.GetBureau(id);
            if (elector == null)
            {
                return NotFound();
            }
            await _bureauService.UpdateBureau(id, name, capacite);
            return Ok();
        }

        // DELETE: api/Bureau/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var bureau = await _bureauService.GetBureau(id);
            if (bureau == null)
            {
                return NotFound();
            }
            await _bureauService.RemoveBureau(id);
            return Ok();
        }

         // DELETE: api/Bureaux
        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            await _bureauService.RemoveAllBureaux();
            return Ok();
        }
 
    }
}
