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
using Taller_Mecanico.Common.Models;

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
        private readonly IMailHelper _mailHelper;

        public UsuariosController(DataContext context, IUsuarioHelper usuarioHelper, ICombosHelper combosHelper, IConverterHelper converterHelper, IBlobHelper blobHelper, IMailHelper mailHelper)
        {
            _context = context;
            _usuarioHelper = usuarioHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _blobHelper = blobHelper;
            _mailHelper = mailHelper;
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

                Usuario usuario = await _converterHelper.toUsuarioAsync(model, imageId, true);
                usuario.TipoUsuario = TipoUsuario.Usuario;
                await _usuarioHelper.AddUsuarioAsync(usuario, "123456");
                await _usuarioHelper.AddUsuarioToRoleAsync(usuario, usuario.TipoUsuario.ToString());

                string myToken = await _usuarioHelper.GenerateEmailConfirmationTokenAsync(usuario);
                string tokenLink = Url.Action("ConfirmEmail", "Account", new
                {
                    usuarioId = usuario.Id,
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                Response response = _mailHelper.SendMail(model.Email, "Vehicles - Confirmación de cuenta", $"<h1>Vehicles - Confirmación de cuenta</h1>" +
                    $"Para habilitar el usuario, " +
                    $"por favor hacer clic en el siguiente enlace: </br></br><a href = \"{tokenLink}\">Confirmar Email</a>");

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


        public async Task<ActionResult> EditVehiculo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo vehiculo = await _context.Vehiculos
                .Include(x => x.Usuario)
                .Include(x => x.Marca)
                .Include(x => x.TipoVehiculo)
                .Include(x => x.VehiculoFotos)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            VehiculoViewModel model = _converterHelper.toVeihculoViewModel(vehiculo);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVehiculo(int id, VehiculoViewModel vehiculoViewModel)
        {
            if (id != vehiculoViewModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Vehiculo vehiculo = await _converterHelper.toVehiculoAsync(vehiculoViewModel, false);
                    _context.Vehiculos.Update(vehiculo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = vehiculoViewModel.UsuarioId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un vehiculo con esta placa.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }                   
                }
                catch(Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            vehiculoViewModel.TipoVehiculos = _combosHelper.GetComboTipoVehiculo();
            vehiculoViewModel.Marcas = _combosHelper.GetComboMarcas();
            return View(vehiculoViewModel);
        }

        public async Task<IActionResult> DeleteVehiculo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo vehiculo = await _context.Vehiculos
                .Include(x => x.Usuario)
                .Include(x => x.VehiculoFotos)
                .Include(x => x.Historias)
                .ThenInclude(X => X.Detalles)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            foreach (VehiculoFoto vPhoto in vehiculo.VehiculoFotos)
            {
                await _blobHelper.DeleteBlobAsync(vPhoto.ImageId, "vehiculo");
            }
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id= vehiculo.Usuario.Id});
        }

        public async Task<IActionResult> DeleteImageVehiculo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehiculoFoto vehiculoFoto = await _context.VehiculoFotos
                .Include(x => x.Vehiculo)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (vehiculoFoto == null)
            {
                return NotFound();
            }
            try
            {
                await _blobHelper.DeleteBlobAsync(vehiculoFoto.ImageId, "vehiculo");
            }
            catch
            {
            }     
            _context.VehiculoFotos.Remove(vehiculoFoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EditVehiculo), new { id = vehiculoFoto.Vehiculo.Id });
        }

        public async Task<IActionResult> AddVehiculoImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(x => x.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            VehiculoFotoViewModel modelo = new VehiculoFotoViewModel
            {
                VehiculoId = vehiculo.Id
            };
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehiculoImage(VehiculoFotoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = await _blobHelper.UploadBlobAsync(modelo.ImageFile, "vehiculo");
                Vehiculo vehiculo = await _context.Vehiculos
                    .Include(x=> x.VehiculoFotos)
                .FirstOrDefaultAsync(x => x.Id == modelo.VehiculoId);
                if (vehiculo.VehiculoFotos == null)
                {
                    vehiculo.VehiculoFotos = new List<VehiculoFoto>();
                }

                vehiculo.VehiculoFotos.Add(new VehiculoFoto
                {
                    ImageId = imageId
                });
                _context.Vehiculos.Update(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(EditVehiculo), new { id = vehiculo.Id });
            }
            return View(modelo);
        }

        public async Task<ActionResult> DetailsVehiculo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Vehiculo vehiculo = await _context.Vehiculos
                .Include(x => x.Usuario)
                .Include(x=> x.TipoVehiculo)
                .Include(x=> x.Marca)
                .Include(x=> x.VehiculoFotos)
                .Include(x=> x.Historias)
                .ThenInclude(x=> x.Detalles)
                .ThenInclude(x=> x.Procedure)
                .Include(x => x.Historias)
                .ThenInclude(x=>x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        public async Task<ActionResult> AddHistoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            HistoriaViewModel modelo = new HistoriaViewModel
            {
                VehiculoId = vehiculo.Id
            };
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddHistoria(HistoriaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                Vehiculo vehiculo = await _context.Vehiculos
                    .Include(x=> x.Historias)
                    .FirstOrDefaultAsync(x => x.Id == modelo.VehiculoId);
                if (vehiculo == null)
                {
                    return NotFound();
                }

                Usuario user = await _usuarioHelper.GetUsuarioAsync(User.Identity.Name);
                Historial historial = new Historial
                {
                    Fecha = DateTime.UtcNow,
                    Kilometraje = modelo.Kilometraje,
                    Obesersacion = modelo.Obesersacion,
                    Usuario = user
                };
                if (vehiculo.Historias == null)
                {
                    vehiculo.Historias = new List<Historial>();
                }
                vehiculo.Historias.Add(historial);
                _context.Update(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DetailsVehiculo), new { id = vehiculo.Id });
            }
            return View(modelo);
        }

        public async Task<ActionResult> EditHistoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Historial historial = await _context.Historiales
                .Include(x => x.Vehiculo)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (historial == null)
            {
                return NotFound();
            }

            HistoriaViewModel model = new HistoriaViewModel
            {
                Kilometraje = historial.Kilometraje,
                Obesersacion = historial.Obesersacion,
                VehiculoId = historial.Vehiculo.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditHistoria(int id, HistoriaViewModel historiaViewModel)
        {
            if (ModelState.IsValid)
            {

                Historial historial = await _context.Historiales.FindAsync(id);
                historial.Kilometraje = historiaViewModel.Kilometraje;
                historial.Obesersacion = historiaViewModel.Obesersacion;
                _context.Historiales.Update(historial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DetailsVehiculo), new { id = historiaViewModel.VehiculoId });

            }

            return View(historiaViewModel);
        }

        public async Task<IActionResult> DeleteHistoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Historial historial = await _context.Historiales
                .Include(x => x.Detalles)
                .Include(x => x.Vehiculo)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (historial == null)
            {
                return NotFound();
            }

            _context.Historiales.Remove(historial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DetailsVehiculo), new { id = historial.Vehiculo.Id });
        }

        public async Task<IActionResult> DetailsHistoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Historial historia = await _context.Historiales
                .Include(x => x.Detalles)
                .ThenInclude(x => x.Procedure)
                .Include(x => x.Vehiculo)
                .ThenInclude(x => x.VehiculoFotos)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }


        public async Task<ActionResult> AddDetalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Historial historial = await _context.Historiales.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }

            DetalleViewModel modelo = new DetalleViewModel
            {
                HistorialId = historial.Id,
               Procedures = _combosHelper.GetComboProcedures()
            };
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDetalle(DetalleViewModel detalleViewModel)
        {
            if (ModelState.IsValid)
            {
                Historial historial = await _context.Historiales
                    .Include(x => x.Detalles)
                    .FirstOrDefaultAsync(x => x.Id == detalleViewModel.HistorialId);
                if (historial == null)
                {
                    return NotFound();
                }

                if (historial.Detalles == null)
                {
                    historial.Detalles = new List<Detalle>();
                }

                Detalle detalle = await _converterHelper.ToDetalleAsync(detalleViewModel, true);
                historial.Detalles.Add(detalle);
                _context.Historiales.Update(historial);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(DetailsHistoria), new { id = detalleViewModel.HistorialId });
            }

            detalleViewModel.Procedures = _combosHelper.GetComboProcedures();
            return View(detalleViewModel);
        }

        public async Task<ActionResult> EditDetalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Detalle detalle = await _context.Detalles
                .Include(x => x.Historial)
                .Include(x => x.Procedure)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (detalle == null)
            {
                return NotFound();
            }

            DetalleViewModel modelo = _converterHelper.ToDetalleViewModel(detalle);

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDetalle(int id, DetalleViewModel detalleViewModel)
        {
            if (ModelState.IsValid)
            {
                Detalle detalle = await _converterHelper.ToDetalleAsync(detalleViewModel, false);
                _context.Detalles.Update(detalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DetailsHistoria), new { id = detalleViewModel.HistorialId });
            }

            detalleViewModel.Procedures = _combosHelper.GetComboProcedures();
            return View(detalleViewModel);
        }

        public async Task<IActionResult> DeleteDetalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Detalle detalle = await _context.Detalles
                .Include(x => x.Historial)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.Detalles.Remove(detalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DetailsHistoria), new { id = detalle.Historial.Id });
        }



    }

}


