using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudWithContextDatabase.Models;

namespace SimpleCrudWithContextDatabase.Controllers {
    public class MovieController : ControllerBase {
        MovieController () {

        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            return Ok (new { });
        }

        [HttpGet ("{Id}")]
        public async Task<IActionResult> Get (string Id) {
            return Ok (new { });
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Movie movie) {
            return Ok (new { });
        }

        [HttpPut ("{Id}")]
        public async Task<IActionResult> Put (string Id, [FromBody] Movie movie) {
            return Ok (new { });
        }

        [HttpDelete ("{Id}")]
        public async Task<IActionResult> Delete (string Id) {
            return Ok (new { });
        }

    }
}