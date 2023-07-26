namespace NutritionistApp.Models
{
    public class AlimentoModel
    {
        public int Id {get;set;}
        public string? Nome {get;set;}
        public string? Descricao {get;set;}
        public string? Categoria {get;set;}
        public double Carboidrato {get;set;}
        public double Proteina {get;set;}
        public double Gordura { get; set; }
    }
}
