using bingoElector.Models;
using bingoElector.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bingoElector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectorController : ControllerBase
    {
        private readonly ElectorService _electorService ;

        public ElectorController(ElectorService electorService)
        {
            _electorService = electorService;
        }
        // GET: api/Electors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elector>>> Get()
        {
            var result = await _electorService.GetAllElectors();
            return Ok(result);
        }

        // GET: api/Elector/5
        [HttpGet("{id}", Name = "GetElector")]
        public async Task<ActionResult<Elector>> Get(string id)
        {
            var elector = await _electorService.GetElector(id);
            return (elector == null) ? NotFound() : Ok(elector);
        }

        // POST: api/Elector
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Elector elector)
        {
            await _electorService.AddElector(elector);
            return Ok();
        }

        // PUT: api/Elector/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] string lastName, string firstName, string lieu, string bureau)
        {
            var elector = await _electorService.GetElector(id);
            await _electorService.UpdateElector(id, lastName, firstName, lieu, bureau);
            return (elector == null) ? NotFound() : Ok();
        }

        // DELETE: api/Elector/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var elector = await _electorService.GetElector(id);
            await _electorService.RemoveElector(id);
             return (elector == null) ? NotFound() : Ok();
        }

        // DELETE: api/Electors
        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            await _electorService.RemoveAllElectors();
            return Ok();
        }


    }
}
