namespace WebAPI.Models
{
    public class Postagem
    {
        public int PostagemId { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? DataPublicacao { get; set; }
        public string? Conteudo { get; set; }

    }
}
