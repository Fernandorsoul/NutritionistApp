using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutritionistApp.Data;
using NutritionistApp.Models;
using NutritionistApp.Repositories.Interfaces;

namespace NutritionistApp.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext dataContext;
        public UsuarioRepository(DataContext _context)
        {
           dataContext = _context;
        }
        public async Task<IEnumerable<UsuarioModel>> GetAllUsuarios()
        {
            return dataContext.Usuarios.ToList();
        }

        public async Task<UsuarioModel> GetUsuarioByEmail(string email)
        {

            var usuarios = dataContext.Usuarios.OrderByDescending(x => x.Email == email);
            return usuarios.FirstOrDefault();

        }

        public async Task<ActionResult<UsuarioModel>> GetUsuarioById(int id)
        {
            var usuario = await dataContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }

        public async Task<ActionResult<UsuarioModel>> GetUsuarioUpdate(UsuarioModel usuario, int id)
        {

            var usuarioPorId = await dataContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            usuario.Nome = usuario.Nome;
            usuario.Email = usuario.Email;

            dataContext.SaveChanges();
            return usuarioPorId;
        }
        public async Task<UsuarioModel> GetCreate([FromBody]UsuarioModel usuario, int id)
{

        var newUsuario = new UsuarioModel();
        newUsuario.Id = id + 1;
        newUsuario.Nome = usuario.Nome;
        dataContext.Usuarios.Add(newUsuario);
        dataContext.SaveChanges();
        return newUsuario;
}
         public async Task<bool> Delete(int id)
        {
            var usuarioPorId = await dataContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            dataContext.Usuarios.Remove(usuarioPorId);
            dataContext.SaveChanges();

            return(usuarioPorId == null);


        }
    }
}
