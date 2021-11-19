using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data;
using Taller_Mecanico.API.Data.Entities;
using Taller_Mecanico.API.Models;

namespace Taller_Mecanico.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<Detalle> ToDetalleAsync(DetalleViewModel model, bool isnew)
        {
            return new Detalle
            {
                Id = isnew ? 0 : model.Id,
                Historial = await _context.Historiales.FindAsync(model.HistorialId),
                PrecioLabor = model.PrecioLabor,
                Procedure = await _context.Procedures.FindAsync(model.ProcedureId),
                Observaciones = model.Observaciones,
                PrecioRepuestos = model.PrecioRepuestos
            };
        }

        public DetalleViewModel ToDetalleViewModel(Detalle detalle)
        {
            return new DetalleViewModel
            {
                HistorialId = detalle.Historial.Id,
                Id = detalle.Id,
                PrecioLabor = detalle.PrecioLabor,
                ProcedureId = detalle.Procedure.Id,
                Procedures = _combosHelper.GetComboProcedures(),
                Observaciones = detalle.Observaciones,
                PrecioRepuestos = detalle.PrecioRepuestos
            };
        }

        public async Task<Usuario> toUsuarioAsync(UsuarioViewModel model, Guid imageId, bool isNew)
        {
            return new Usuario
            {
                 Direccion = model.Direccion,
                 Documento = model.Documento,
                 TipoDocumento = await _context.TipoDocumentos.FindAsync(model.TipoDocumentoId),
                 Email = model.Email,
                 Nombres = model.Nombres,
                 Id = isNew ? Guid.NewGuid().ToString() : model.Id,
                 ImageId = imageId,
                 Apellidos = model.Apellidos,
                 PhoneNumber = model.PhoneNumber,
                 UserName = model.Email,
                 TipoUsuario = model.TipoUsuario,


            };
        }

        public UsuarioViewModel toUsuarioViewModel(Usuario usuario)
        {
            return new UsuarioViewModel
            {
                Direccion = usuario.Direccion,
                Documento = usuario.Documento,
                TipoDocumentoId = usuario.TipoDocumento.Id,
                TipoDocumentos = _combosHelper.GetComboTipoDocumentos(),
                Email = usuario.Email,
                Nombres = usuario.Nombres,
                Id = usuario.Id,
                ImageId = usuario.ImageId,
                Apellidos = usuario.Apellidos,
                PhoneNumber = usuario.PhoneNumber,
                TipoUsuario = usuario.TipoUsuario,
            };
        }

        public async Task<Vehiculo> toVehiculoAsync(VehiculoViewModel model, bool isNew)
        {
            return new Vehiculo
            {
                Marca = await _context.Marcas.FindAsync(model.MarcaId),
                Color = model.Color,
                Id = isNew ? 0 : model.Id,
                Linea = model.Linea,
                Modelo = model.Modelo,
                Placa = model.Placa.ToUpper(),
                Observaciones = model.Observaciones,
                TipoVehiculo = await _context.TipoVehiculos.FindAsync(model.TipoVehiculoId)
            };
        }

        public VehiculoViewModel toVeihculoViewModel(Vehiculo vehiculo)
        {
            return new VehiculoViewModel
            {
                MarcaId = vehiculo.Marca.Id,
                Marcas = _combosHelper.GetComboMarcas(),
                Color = vehiculo.Color,
                Id = vehiculo.Id,
                Linea = vehiculo.Linea,
                Modelo = vehiculo.Modelo,
                Placa = vehiculo.Placa.ToUpper(),
                Observaciones = vehiculo.Observaciones,
                UsuarioId = vehiculo.Usuario.Id,
                VehiculoFotos = vehiculo.VehiculoFotos,
                TipoVehiculoId = vehiculo.TipoVehiculo.Id,
                TipoVehiculos = _combosHelper.GetComboTipoVehiculo()
            };
        }
    }
}
