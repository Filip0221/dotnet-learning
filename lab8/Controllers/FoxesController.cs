using Microsoft.AspNetCore.Mvc;
using lab8.Data;
using lab8.Models;
using Microsoft.AspNetCore.Authorization;

namespace lab8.Controllers
{
    [ApiController]
    [Route("api/fox")]
    public class FoxesController : ControllerBase
    {
        private readonly IFoxesRepository _repo;

        public FoxesController(IFoxesRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Fox> Get()
        {
            return _repo.GetAll()
                .OrderByDescending(f => f.Loves)
                .ThenBy(f => f.Hates);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var fox = _repo.Get(id);
            if (fox == null)
                return NotFound();

            return Ok(fox);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Fox fox)
        {
            _repo.Add(fox);
            return CreatedAtAction(nameof(Get), new { id = fox.Id }, fox);
        }

        // [HttpPut("{id}")]
        // [Authorize]
        // public IActionResult Put(int id, [FromBody] Fox fox)
        // {
        //     var existing = _repo.Get(id);
        //     if (existing == null)
        //         return NotFound();

        //     _repo.Update(id, fox);
        //     return NoContent();
        // }
        [HttpPut("love/{id}")]
        public IActionResult Love(int id)
        {
            var fox = _repo.Get(id);
            if (fox == null)
                return NotFound();

            fox.Loves++;
            _repo.Update(id, fox);
            return Ok(fox);
        }

        [HttpPut("hate/{id}")]
        public IActionResult Hate(int id)
        {
            var fox = _repo.Get(id);
            if (fox == null)
                return NotFound();

            fox.Hates++;
            _repo.Update(id, fox);
            return Ok(fox);
        }

    }
}
