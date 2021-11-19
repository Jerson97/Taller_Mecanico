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
