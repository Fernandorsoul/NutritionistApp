using Microsoft.AspNetCore.Mvc;
using NutritionistApp.Models;

namespace NutritionistApp.Repositories.Interfaces
{
    public interface IAlimentoRepository
    {
        Task<IEnumerable<AlimentoModel>> GetAllAlimentos();
        Task<ActionResult<AlimentoModel>> GetAlimentoById(int id);
        Task<ActionResult<AlimentoModel>> GetAlimentoUpdate(AlimentoModel alimento, int id);
        Task<AlimentoModel> GetCreate([FromBody] AlimentoModel alimento, int id);
        Task<bool> Delete(int id);
    }
}
