using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data;
using Taller_Mecanico.API.Data.Entities;
using Taller_Mecanico.API.Models;
using Taller_Mecanico.Common.Enumeracion;

namespace Taller_Mecanico.API.Helpers
{
    public class UsuarioHelper : IUsuarioHelper
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioHelper(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, DataContext context, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUsuarioAsync(Usuario usuario, string password)
        {
            return await _userManager.CreateAsync(usuario, password);
        }

        public async Task<Usuario> AddUsuarioAsync(AddUsuarioViewModel model, Guid imageId, TipoUsuario tipoUsuario)
        {
            Usuario usuario = new Usuario
            {
                Direccion = model.Direccion,
                Documento = model.Documento,
                Email = model.Username,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                ImageId = imageId,
                PhoneNumber = model.PhoneNumber,
                TipoDocumento = await _context.TipoDocumentos.FindAsync(model.TipoDocumentoId),
                UserName = model.Username,
                TipoUsuario = tipoUsuario
            };

            IdentityResult result = await _userManager.CreateAsync(usuario, model.Password);
            if (result != IdentityResult.Success)
            {
                return null;
            }
            Usuario nuevoUsuario = await GetUsuarioAsync(model.Username);
            await AddUsuarioToRoleAsync(nuevoUsuario, usuario.TipoUsuario.ToString());
            return nuevoUsuario;

        }

        public async Task AddUsuarioToRoleAsync(Usuario usuario, string roleName)
        {
            await _userManager.AddToRoleAsync(usuario, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        public async Task<IdentityResult> DeleteUsuarioAsync(Usuario usuario)
        {
            return await _userManager.DeleteAsync(usuario);
        }

        public async Task<Usuario> GetUsuarioAsync(string email)
        {
            return await _context.Users
                .Include(x => x.TipoDocumento)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.VehiculoFotos)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.Historias)
                .ThenInclude(x => x.Detalles)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Usuario> GetUsuarioAsync(Guid id)
        {
            return await _context.Users
                .Include(x => x.TipoDocumento)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.VehiculoFotos)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.Historias)
                .ThenInclude(x => x.Detalles)
                .FirstOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task<bool> IsUserInRoleAsync(Usuario usuario, string roleName)
        {
            return await _userManager.IsInRoleAsync(usuario, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUsuarioAsync(Usuario usuario)
        {
            Usuario usuarioAcual = await GetUsuarioAsync(usuario.Email);
            usuarioAcual.Apellidos = usuario.Apellidos;
            usuarioAcual.Nombres = usuario.Nombres;
            usuarioAcual.TipoDocumento = usuario.TipoDocumento;
            usuarioAcual.Documento = usuario.Documento;
            usuarioAcual.Direccion = usuario.Direccion;
            usuarioAcual.ImageId = usuario.ImageId;
            usuarioAcual.PhoneNumber = usuario.PhoneNumber;
            return await _userManager.UpdateAsync(usuarioAcual);
        }
    }
}
