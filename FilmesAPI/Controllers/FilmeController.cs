using FilmesAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : Controller
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new {id = filme.Id}, filme);
        }
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilme([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            return filmes.Skip(offset).Take(limit);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id) 
        {
            var filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }
    }
}
