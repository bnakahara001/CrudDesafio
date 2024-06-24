namespace CrudDesafio.Models
{
    public class RepositorioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Linguagem { get; set; } = string.Empty;
        public DateTime UltimaAtualizacao { get; set; }
        public string DonoRepositorio { get; set; } = string.Empty;
        public bool Favorito { get; set; } = false;
    }
}
