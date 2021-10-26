using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data;
using Taller_Mecanico.API.Data.Entities;
using Taller_Mecanico.API.Helpers;
using Taller_Mecanico.API.Models;
using Taller_Mecanico.Common.Enumeracion;

namespace Taller_Mecanico.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly DataContext _context;
        private readonly IUsuarioHelper _usuarioHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IBlobHelper _blobHelper;

        public UsuariosController(DataContext context, IUsuarioHelper usuarioHelper, ICombosHelper combosHelper, IConverterHelper converterHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _usuarioHelper = usuarioHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _blobHelper = blobHelper;
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
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            Usuario usuario = await _usuarioHelper.GetUsuarioAsync(Guid.Parse(id));

            if (usuario == null)
            {
                return NotFound();
            }


            UsuarioViewModel model = _converterHelper.toUsuarioViewModel(usuario);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                    Guid imageId = model.ImageId;
                    if (model.ImageFile != null)
                    {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "usuario");
                    }

                    Usuario usuario = await _converterHelper.toUsuarioAsync(model, imageId, false);
                    await _usuarioHelper.UpdateUsuarioAsync(usuario);
                    return RedirectToAction(nameof(Index));
                }

            model.TipoDocumentos = _combosHelper.GetComboTipoDocumentos();    
            return View(model);
        }
    }

    }

