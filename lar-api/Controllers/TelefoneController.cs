using Microsoft.AspNetCore.Mvc;
using lar-api.Models; // Use o namespace correto onde seu modelo está definido
using System.Collections.Generic;
using System.Linq;

namespace lar-api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelefoneController : ControllerBase
    {
        private readonly List<Telefone> _telefones;

        public TelefoneController(List<Telefone> telefones)
        {
            _telefones = telefones;
        }

        // GET: /Telefone
        [HttpGet]
        public ActionResult<List<Telefone>> Get()
        {
            return _telefones;
        }

        // GET: /Telefone/{id}
        [HttpGet("{id}")]
        public ActionResult<Telefone> Get(int id)
        {
            var telefone = _telefones.FirstOrDefault(t => t.TelefoneId == id);
            if (telefone == null)
                return NotFound();

            return telefone;
        }

        // POST: /Telefone
        [HttpPost]
        public ActionResult<Telefone> Post([FromBody] Telefone telefone)
        {
            _telefones.Add(telefone);
            return CreatedAtAction(nameof(Get), new { id = telefone.TelefoneId }, telefone);
        }

        // PUT: /Telefone/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Telefone telefone)
        {
            var index = _telefones.FindIndex(t => t.TelefoneId == id);
            if (index < 0)
                return NotFound();

            _telefones[index] = telefone;
            return NoContent();
        }

        // DELETE: /Telefone/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = _telefones.FindIndex(t => t.TelefoneId == id);
            if (index < 0)
                return NotFound();

            _telefones.RemoveAt(index);
            return NoContent();
        }
    }
}
