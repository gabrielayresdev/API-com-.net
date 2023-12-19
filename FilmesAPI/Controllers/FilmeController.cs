using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : Controller
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new {id = filme.Id}, filme);
        }
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilme([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            return _context.Filmes.Skip(offset).Take(limit);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id) 
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }
    }
}
