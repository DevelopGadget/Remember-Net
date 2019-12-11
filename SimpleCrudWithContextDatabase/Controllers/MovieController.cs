using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudWithContextDatabase.DB;
using SimpleCrudWithContextDatabase.Models;

namespace SimpleCrudWithContextDatabase.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase {

        private readonly MovieDbContext _database;

        public MovieController (MovieDbContext context) {
            this._database = context;;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            return Ok (await this._database.get ());
        }

        [HttpGet ("{Id}")]
        public async Task<IActionResult> Get (string Id) {
            return Ok (await this._database.get (Id));
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Movie movie) {
            if (!ModelState.IsValid) return BadRequest (ModelState);
            return Ok (await this._database.post (movie));
        }

        [HttpPut ("{Id}")]
        public async Task<IActionResult> Put (string Id, [FromBody] Movie movie) {
            return Ok (await this._database.put (Id, movie));
        }

        [HttpDelete ("{Id}")]
        public async Task<IActionResult> Delete (string Id) {
            return Ok (await this._database.delete (Id));
        }

    }
}