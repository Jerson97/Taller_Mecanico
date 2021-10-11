using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Helpers;
using Taller_Mecanico.API.Models;

namespace Taller_Mecanico.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioHelper _usuarioHelper;

        public AccountController(IUsuarioHelper usuarioHelper)
        {
            _usuarioHelper = usuarioHelper;
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
    }
}
