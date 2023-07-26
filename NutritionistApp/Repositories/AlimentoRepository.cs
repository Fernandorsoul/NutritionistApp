using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutritionistApp.Data;
using NutritionistApp.Models;
using NutritionistApp.Repositories.Interfaces;

namespace NutritionistApp.Repositories
{
    public class AlimentoRepository : IAlimentoRepository
    {
        
        private readonly DataContext _dataContext;
        public AlimentoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<AlimentoModel>> GetAllAlimentos()
        {
            return await _dataContext.Alimentos.ToListAsync();
        }

        public async Task<ActionResult<AlimentoModel>> GetAlimentoById(int id)
        {
            var alimentoById = await _dataContext.Alimentos.FirstOrDefaultAsync(x => x.Id == id );
            return (alimentoById);
        }
             
        public async Task<ActionResult<AlimentoModel>> GetAlimentoUpdate(AlimentoModel alimento, int id)
        {
            var alimentoPorId = await _dataContext.Alimentos.FirstOrDefaultAsync(x => x.Id == id);
            alimento.Nome = alimento.Nome;
            alimento.Descricao = alimento.Descricao;

            _dataContext.SaveChanges();
            return alimentoPorId;

        }

        public  Task<AlimentoModel> GetCreate([FromBody] AlimentoModel alimento, int id)
        {
            var newAlimento = new AlimentoModel
            {
                Id = id + 1,
                Nome = alimento.Nome,
                Descricao = alimento.Descricao,
                Categoria = alimento.Categoria,
                Carboidrato = alimento.Carboidrato,
                Proteina = alimento.Proteina,
                Gordura = alimento.Gordura,

            };
            

            _dataContext.Alimentos.Add(newAlimento);
            _dataContext.SaveChanges();
            return Task.FromResult(newAlimento);
        }


        public async Task<bool> Delete(int id)
        {
            var alimentoPorId = await _dataContext.Alimentos.FirstOrDefaultAsync(x => x.Id == id);
            _dataContext.Alimentos.Remove(alimentoPorId);
            _dataContext.SaveChanges();

            return (alimentoPorId == null);
        }
    }
}
