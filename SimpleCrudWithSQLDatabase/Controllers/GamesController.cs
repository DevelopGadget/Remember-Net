using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudWithSQLDatabase.DB;
using SimpleCrudWithSQLDatabase.Models;

namespace SimpleCrudWithSQLDatabase.Controllers {
    [ApiController]
    [Route ("[Controller]")]
    public class GamesController : ControllerBase {

        private readonly GamesDBContext _database;

        public GamesController (GamesDBContext _database) {
            this._database = _database;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            return Ok (await this._database.Get ());
        }

        [HttpGet ("{Id}")]
        public async Task<IActionResult> Get (int Id) {
            return Ok (await this._database.Get (Id));
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Game game) {
            if (!ModelState.IsValid)
                return StatusCode (406, ModelState);
            return Ok (await this._database.Post (game));
        }

        [HttpPut ("{Id}")]
        public async Task<IActionResult> Put (int Id, [FromBody] Game game) {
            if (!ModelState.IsValid)
                return StatusCode (406, ModelState);
            return Ok (await this._database.Put(Id, game));
        }

        [HttpDelete ("{Id}")]
        public async Task<IActionResult> Delete (int Id) {
            return Ok (await this._database.Delete(Id));
        }
    }
}