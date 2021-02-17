using Microsoft.AspNetCore.Mvc;
using nhOmega.GameTracker.Core.Models;
using nhOmega.GameTracker.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nhOmega.GameTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;

        private IGamesRepository Games => _gamesRepository;

        public ValuesController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return await Games.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            var game = await Games.Get(id);

            if (game is null)
            {
                return NotFound();
            }

            return game;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Game game)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    await Games.Update(game);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return NotFound();
                }
                return Ok();
            }
            return UnprocessableEntity(ModelState);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Game game)
        {
            if (ModelState.IsValid)
            {
                await Games.Create(game);
                return Ok();
            }
            return UnprocessableEntity(ModelState);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await Games.Delete(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
