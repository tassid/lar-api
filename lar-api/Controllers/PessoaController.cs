using Microsoft.AspNetCore.Mvc;
using lar-api.Models; // Use o namespace correto onde seu modelo está definido
using System.Collections.Generic;
using System.Linq;

namespace lar-api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly List<Pessoa> _pessoas;

        public PessoaController(List<Pessoa> pessoas)
        {
            _pessoas = pessoas;
        }

        // GET: /Pessoa
        [HttpGet]
        public ActionResult<List<Pessoa>> Get()
        {
            return _pessoas;
        }

        // GET: /Pessoa/{id}
        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(int id)
        {
            var pessoa = _pessoas.FirstOrDefault(p => p.PessoaId == id);
            if (pessoa == null)
                return NotFound();

            return pessoa;
        }

        // POST: /Pessoa
        [HttpPost]
        public ActionResult<Pessoa> Post([FromBody] Pessoa pessoa)
        {
            _pessoas.Add(pessoa);
            return CreatedAtAction(nameof(Get), new { id = pessoa.PessoaId }, pessoa);
        }

        // PUT: /Pessoa/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            var index = _pessoas.FindIndex(p => p.PessoaId == id);
            if (index < 0)
                return NotFound();

            _pessoas[index] = pessoa;
            return NoContent();
        }

        // DELETE: /Pessoa/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = _pessoas.FindIndex(p => p.PessoaId == id);
            if (index < 0)
                return NotFound();

            _pessoas.RemoveAt(index);
            return NoContent();
        }
    }
}
