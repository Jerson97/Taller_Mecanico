using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data;
using Taller_Mecanico.API.Data.Entities;
using Taller_Mecanico.API.Helpers;
using Taller_Mecanico.API.Models;
using Taller_Mecanico.Common.Enumeracion;

namespace Taller_Mecanico.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        private readonly IUsuarioHelper _usuarioHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IBlobHelper _blobHelper;

        public AccountController(DataContext context, IUsuarioHelper usuarioHelper, ICombosHelper combosHelper, IConverterHelper converterHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _usuarioHelper = usuarioHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _blobHelper = blobHelper;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               var resultado = await _usuarioHelper.LoginAsync(model);
                if (resultado.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _usuarioHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registrar()
        {
            AddUsuarioViewModel model = new AddUsuarioViewModel
            {
                TiposDocumentos = _combosHelper.GetComboTipoDocumentos()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(AddUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "usuario");
                }

                Usuario user = await _usuarioHelper.AddUsuarioAsync(model, imageId, TipoUsuario.Usuario);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado por otro usuario.");
                    model.TiposDocumentos = _combosHelper.GetComboTipoDocumentos();
                    return View(model);
                }
                LoginViewModel loginViewModel = new LoginViewModel
                {
                    Password = model.Password,
                    RememberMe = false,
                    Username = model.Username
                };
                var result2 = await _usuarioHelper.LoginAsync(loginViewModel);
                if (result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            model.TiposDocumentos = _combosHelper.GetComboTipoDocumentos();
            return View(model);
        }

        public async Task<IActionResult> ChangeUser()
        {
            Usuario usuario = await _usuarioHelper.GetUsuarioAsync(User.Identity.Name);
            if (usuario == null)
            {
                return NotFound();
            }

            EditUsuarioViewModel model = new()
            {
                Direccion = usuario.Direccion,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                PhoneNumber = usuario.PhoneNumber,
                ImageId = usuario.ImageId,
                Id = usuario.Id,
                Documento = usuario.Documento,
                TipoDocumentoId = usuario.TipoDocumento.Id,
                TiposDocumentos = _combosHelper.GetComboTipoDocumentos(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUser(EditUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = model.ImageId;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }

                Usuario usuario = await _usuarioHelper.GetUsuarioAsync(User.Identity.Name);
                usuario.Nombres = model.Nombres;
                usuario.Apellidos = model.Apellidos;
                usuario.Direccion = model.Direccion;
                usuario.PhoneNumber = model.PhoneNumber;
                usuario.ImageId = imageId;
                usuario.TipoDocumento = await _context.TipoDocumentos.FindAsync(model.TipoDocumentoId);
                usuario.Documento = model.Documento;
                await _usuarioHelper.UpdateUsuarioAsync(usuario);
                return RedirectToAction("Index", "Home");
            }

            model.TiposDocumentos = _combosHelper.GetComboTipoDocumentos();
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _usuarioHelper.GetUsuarioAsync(User.Identity.Name);
                if (usuario != null)
                {
                    IdentityResult result = await _usuarioHelper.ChangePasswordAsync(usuario, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(ChangeUser));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                }
            }

            return View(model);
        }

    }
}
