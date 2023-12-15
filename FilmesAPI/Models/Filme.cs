using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public Filme(string titulo, string genero, int duracao)
        {
            Titulo = titulo;
            Genero = genero;
            Duracao = duracao;
        }

        [Required(ErrorMessage = "O título do filme é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O gênero do filme é obrigatório")]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600, ErrorMessage = "O filme deve ter entre 70 a 600 minutos")]
        public int Duracao { get; set; }
    }
}
