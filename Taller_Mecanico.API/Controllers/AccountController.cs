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
using Taller_Mecanico.Common.Models;

namespace Taller_Mecanico.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        private readonly IUsuarioHelper _usuarioHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly IMailHelper _mailHelper;

        public AccountController(DataContext context, IUsuarioHelper usuarioHelper, ICombosHelper combosHelper, IConverterHelper converterHelper, IBlobHelper blobHelper, IMailHelper mailHelper)
        {
            _context = context;
            _usuarioHelper = usuarioHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _blobHelper = blobHelper;
            _mailHelper = mailHelper;
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

                Usuario usuario = await _usuarioHelper.AddUsuarioAsync(model, imageId, TipoUsuario.Usuario);
                if (usuario == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado por otro usuario.");
                    model.TiposDocumentos = _combosHelper.GetComboTipoDocumentos();
                    return View(model);
                }

                string myToken = await _usuarioHelper.GenerateEmailConfirmationTokenAsync(usuario);
                string tokenLink = Url.Action("ConfirmEmail", "Account", new
                {
                    usuarioId = usuario.Id,
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                Response response = _mailHelper.SendMail(model.Username, "Taller Mecánico - Confirmación de cuenta", $"<h1>Taller Mecánico - Confirmación de cuenta</h1>" +
                    $"Para habilitar el usuario, " +
                    $"por favor hacer clic en el siguiente enlace: </br></br><a href = \"{tokenLink}\">Confirmar Email</a>");
                if (response.IsSuccess)
                {
                    ViewBag.Message = "Las instrucciones para habilitar su cuenta han sido enviadas al correo.";
                    return View(model);
                }

                ModelState.AddModelError(string.Empty, response.Message);
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
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "usuario");
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

        public async Task<IActionResult> ConfirmEmail(string usuarioId, string token)
        {
            if (string.IsNullOrEmpty(usuarioId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            Usuario usuario = await _usuarioHelper.GetUsuarioAsync(new Guid(usuarioId));
            if (usuario == null)
            {
                return NotFound();
            }

            IdentityResult result = await _usuarioHelper.ConfirmEmailAsync(usuario, token);
            if (!result.Succeeded)
            {
                return NotFound();
            }

            return View();
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _usuarioHelper.GetUsuarioAsync(model.Email);
                if (usuario == null)
                {
                    ModelState.AddModelError(string.Empty, "El correo ingresado no corresponde a ningún usuario.");
                    return View(model);
                }

                string myToken = await _usuarioHelper.GeneratePasswordResetTokenAsync(usuario);
                string link = Url.Action(
                    "ResetPassword",
                    "Account",
                    new { token = myToken }, protocol: HttpContext.Request.Scheme);
                _mailHelper.SendMail(model.Email, "Taller Mecanico - Reseteo de contraseña", $"<h1>Taller Mecanico - Reseteo de contraseña</h1>" +
                    $"Para establecer una nueva contraseña haga clic en el siguiente enlace:</br></br>" +
                    $"<a href = \"{link}\">Cambio de Contraseña</a>");
                ViewBag.Message = "Las instrucciones para el cambio de contraseña han sido enviadas a su email.";
                return View();

            }

            return View(model);
        }

        public IActionResult ResetPassword(string token)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            Usuario usuario = await _usuarioHelper.GetUsuarioAsync(model.UserName);
            if (usuario != null)
            {
                IdentityResult result = await _usuarioHelper.ResetPasswordAsync(usuario, model.Token, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Contaseña cambiada.";
                    return View();
                }

                ViewBag.Message = "Error cambiando la contraseña.";
                return View(model);
            }

            ViewBag.Message = "Usuario no encontrado.";
            return View(model);
        }


        //public async Task<ActionResult> DetailsVehiculo()
        //{
        //    Vehiculo usuario = await _usuarioHelper.GetUsuarioAsync(User.Identity.Name);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }
        //    VehiculoViewModel model = new()
        //    {
        //        Usuario = usuario.Id,
        //        Marca = usuario.Marca,
        //        Direccion = usuario.Direccion,
        //        Nombres = usuario.Nombres,
        //        Apellidos = usuario.Apellidos,
        //        PhoneNumber = usuario.PhoneNumber,
        //        ImageId = usuario.ImageId,
        //        Id = usuario.Id,
        //        Documento = usuario.Documento,
        //        TipoDocumentoId = usuario.TipoDocumento.Id,
        //        TiposDocumentos = _combosHelper.GetComboTipoDocumentos(),
        //    };

        //    return View(model);
        //}
    }
}