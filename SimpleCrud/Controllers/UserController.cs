using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleCrud.Models;

namespace SimpleCrud.Controllers {

    [ApiController]
    [Route ("[controller]")]
    public class UserController : ControllerBase {

        public UserController () {

        }

        [HttpGet]
        public async Task<IActionResult> Get () {

            var jsonFile = await System.IO.File.ReadAllTextAsync (@"./data/data.json");
            var result = JsonConvert.DeserializeObject<List<Users>> (jsonFile);
            return Ok (result);
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Users user) {
            if (ModelState.IsValid) {
                var jsonFile = await System.IO.File.ReadAllTextAsync (@"./data/data.json");
                var result = JsonConvert.DeserializeObject<List<Users>> (jsonFile);
                result.Add (user);
                await System.IO.File.WriteAllTextAsync (@"./data/data.json", JsonConvert.SerializeObject (result));
                return Ok (result);
            }
            return BadRequest (ModelState.Values);
        }

        [HttpGet ("{username}")]
        public async Task<IActionResult> Get (string username) {

            var jsonFile = await System.IO.File.ReadAllTextAsync (@"./data/data.json");
            var result = JsonConvert.DeserializeObject<List<Users>> (jsonFile);
            return Ok (result.Find (user => user.username.Equals (username)));
        }

        [HttpPut ("{username}")]
        public async Task<IActionResult> Put (string username, [FromBody] Users user) {
            if (ModelState.IsValid) {
                var jsonFile = await System.IO.File.ReadAllTextAsync (@"./data/data.json");
                var result = JsonConvert.DeserializeObject<List<Users>> (jsonFile);
                int index = result.FindIndex (user => user.username.Equals (username));
                if (index >= 0) {
                    result[index] = user;
                    await System.IO.File.WriteAllTextAsync (@"./data/data.json", JsonConvert.SerializeObject (result));
                    return Ok (result);
                }
                return NotFound (user);
            }
            return BadRequest (ModelState.Values);
        }

        [HttpDelete ("{username}")]
        public async Task<IActionResult> Delete (string username) {

            var jsonFile = await System.IO.File.ReadAllTextAsync (@"./data/data.json");
            var result = JsonConvert.DeserializeObject<List<Users>> (jsonFile);
            int count = result.RemoveAll (user => user.username.Equals (username));
            await System.IO.File.WriteAllTextAsync (@"./data/data.json", JsonConvert.SerializeObject (result));
            return Ok (new {
                count = count
            });
        }

    }
}