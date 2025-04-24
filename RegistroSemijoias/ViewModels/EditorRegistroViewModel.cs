using System.ComponentModel.DataAnnotations;

namespace RegistroSemijoias.ViewModels
{
    public class EditorRegistroViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter de 3 a 100 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public int Estoque { get; set; }
        public string Categoria { get; set; }
    }
}
