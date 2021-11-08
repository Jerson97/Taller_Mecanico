using Microsoft.AspNetCore.Authorization;
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



        public async Task<IActionResult> Delete(string id)
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

            await _blobHelper.DeleteBlobAsync(usuario.ImageId, "usuario");
            await _usuarioHelper.DeleteUsuarioAsync(usuario);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            Usuario usuario = await _context.Users
                .Include(x => x.TipoDocumento)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.Marca)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.TipoVehiculo)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.VehiculoFotos)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.Historias)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }


        public async Task<ActionResult> AddVehiculo(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            Usuario usuario = await _context.Users
                .Include(x => x.Vehiculos)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            VehiculoViewModel modelo = new VehiculoViewModel
            {
                Marcas = _combosHelper.GetComboMarcas(),
                UsuarioId = usuario.Id,
                TipoVehiculos = _combosHelper.GetComboTipoVehiculo()
            };

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddVehiculo(VehiculoViewModel vehiculoViewModel)
        {
            
                Usuario usuario = await _context.Users
                    .Include(x => x.Vehiculos)
                    .FirstOrDefaultAsync(x => x.Id == vehiculoViewModel.UsuarioId);

                if (usuario == null)
                {
                    return NotFound();
                }

                Guid imageId = Guid.Empty;
                if (vehiculoViewModel.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(vehiculoViewModel.ImageFile, "vehiculo");
                }
                Vehiculo vehiculo = await _converterHelper.toVehiculoAsync(vehiculoViewModel, true);
                if (vehiculo.VehiculoFotos == null)
                {
                    vehiculo.VehiculoFotos = new List<VehiculoFoto>();

                }
                    vehiculo.VehiculoFotos.Add(new VehiculoFoto
                    {
                        ImageId = imageId
                    });

                    try
                    {
                        usuario.Vehiculos.Add(vehiculo);
                        _context.Users.Update(usuario);
                        await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = usuario.Id });
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                        if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                        {
                            ModelState.AddModelError(string.Empty, "Ya existe un vehiculo con esa placa ");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                        }
                    }
                    catch (Exception exception)
                    {
                        ModelState.AddModelError(string.Empty, exception.Message);
                    }
                

                vehiculoViewModel.Marcas = _combosHelper.GetComboMarcas();
                vehiculoViewModel.TipoVehiculos = _combosHelper.GetComboTipoVehiculo();
                return View(vehiculoViewModel);
            }
        }

    }


