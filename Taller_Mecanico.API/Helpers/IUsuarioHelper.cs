using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data.Entities;
using Taller_Mecanico.API.Models;
using Taller_Mecanico.Common.Enumeracion;

namespace Taller_Mecanico.API.Helpers
{
    public interface IUsuarioHelper
    {
        Task<Usuario> GetUsuarioAsync(string email);
        Task<Usuario> GetUsuarioAsync(Guid id);
        Task<IdentityResult> AddUsuarioAsync(Usuario usuario, string password);
        Task<Usuario> AddUsuarioAsync(AddUsuarioViewModel model, Guid imageId, TipoUsuario tipoUsuario);
        Task<IdentityResult> UpdateUsuarioAsync(Usuario usuario);
        Task<IdentityResult> DeleteUsuarioAsync(Usuario usuario);
        Task CheckRoleAsync(string roleName);
        Task AddUsuarioToRoleAsync(Usuario usuario, string roleName);
        Task<bool> IsUserInRoleAsync(Usuario usuario, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task <IdentityResult>ChangePasswordAsync(Usuario usuario, string oldPassword, string newPassword);
        Task<string> GenerateEmailConfirmationTokenAsync(Usuario usuario);
        Task<IdentityResult> ConfirmEmailAsync(Usuario usuario, string token);

        Task<string> GeneratePasswordResetTokenAsync(Usuario usuario);

        Task<IdentityResult> ResetPasswordAsync(Usuario usuario, string token, string password);

        //Task<SignInResult> ValidatePasswordAsync(Usuario user, string password);

    }
}
