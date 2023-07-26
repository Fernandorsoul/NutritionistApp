using NutritionistApp.Enums;

namespace NutritionistApp.Models
{
    public class UsuarioModel
    {
        public int Id {get;set;}
        public string? Nome {get;set;}
        public string? Email {get;set;}
        public string? Senha {get;set;}
        public TipoAtividade? NivelAtividade {get;set;}
        public DateTime DataCriacao {get;set;}
        public double CaloriasPorDia {get; set;}


    }
}
