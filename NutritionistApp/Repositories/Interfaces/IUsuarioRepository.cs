using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionistApp.Models;

namespace NutritionistApp.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioModel>> GetAllUsuarios();
        Task<ActionResult<UsuarioModel>> GetUsuarioById(int id);
        Task<UsuarioModel> GetUsuarioByEmail(string email);
        Task<ActionResult<UsuarioModel>> GetUsuarioUpdate(UsuarioModel usuario, int id);
        Task<UsuarioModel> GetCreate([FromBody]UsuarioModel usuario, int id);
        Task<bool> Delete (int id);
    }
}
