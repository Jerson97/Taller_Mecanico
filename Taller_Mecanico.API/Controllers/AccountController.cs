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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users
                .Include(x => x.TipoDocumento)
                .Include(x => x.Vehiculos)
                .Where(x => x.TipoUsuario == TipoUsuario.Usuario)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            UsuarioViewModel model = new UsuarioViewModel
            {
                TipoDocumentos = _combosHelper.GetComboTipoDocumentos()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel model)
        {

            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "usuario");
                }

                Usuario user = await _converterHelper.toUsuarioAsync(model, imageId, true);
                user.TipoUsuario = TipoUsuario.Usuario;
                await _usuarioHelper.AddUsuarioAsync(user, "123456");
                await _usuarioHelper.AddUsuarioToRoleAsync(user, user.TipoUsuario.ToString());


                return RedirectToAction(nameof(Index));
            }
            model.TipoDocumentos = _combosHelper.GetComboTipoDocumentos();
            return View(model);
        }
    }
}
