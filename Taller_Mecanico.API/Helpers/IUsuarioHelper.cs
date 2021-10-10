using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data.Entities;

namespace Taller_Mecanico.API.Helpers
{
    public interface IUsuarioHelper
    {
        Task<Usuario> GetUsuarioAsync(string email);
        Task<IdentityResult> AddUsuarioAsync(Usuario usuario, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUsuarioToRoleAsync(Usuario usuario, string roleName);
        Task<bool> IsUserInRoleAsync(Usuario usuario, string roleName);
    }
}
