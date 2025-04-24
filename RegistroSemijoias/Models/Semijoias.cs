namespace RegistroSemijoias.Models
{
    public class Semijoias
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string ImagemUrl { get; set; }
        public int Estoque { get; set; }
        public string Categoria { get; set; }

    }
}
