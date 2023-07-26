using Microsoft.EntityFrameworkCore;
using NutritionistApp.Models;

namespace NutritionistApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option)
        : base(option)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<AlimentoModel> Alimentos { get; set; }

    }
}
