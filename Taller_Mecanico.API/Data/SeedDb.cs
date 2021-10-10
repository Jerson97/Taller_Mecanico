using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data.Entities;
using Taller_Mecanico.API.Helpers;
using Taller_Mecanico.Common.Enumeracion;

namespace Taller_Mecanico.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUsuarioHelper _usuarioHelper;

        public SeedDb(DataContext context, IUsuarioHelper usuarioHelper)
        {
            _context = context;
            _usuarioHelper = usuarioHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTipoVehiculoAsync();
            await CheckMarcaAsync();
            await CheckDocumentosAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await ChechUsuarioAsync("75074618","Jerson","Ramirez","jerson@yopmail.com","3361255","Jr.Herrera 247", TipoUsuario.Usuario);
            await ChechUsuarioAsync("85075644","Jose","Soto","jose@yopmail.com","3361472","Jr.Herrera 247", TipoUsuario.Usuario);
            await ChechUsuarioAsync("95165165","Luis","Rodriguez","luis@yopmail.com","33612547","Jr.Herrera 247", TipoUsuario.Usuario);

        }

        private async Task ChechUsuarioAsync(string documento, string Nombre, string Apellido, string email, string phoneNumber, string address, TipoUsuario tipousuario)
        {
            Usuario usuario = await _usuarioHelper.GetUsuarioAsync(email);
            if (usuario == null)
            {
                usuario = new Usuario
                {
                    Direccion = address,
                    Documento = documento,
                    TipoDocumento = _context.TipoDocumentos.FirstOrDefault(x => x.Descripcion == "Cédula"),
                    Email = email,
                    Nombres = Nombre,
                    Apellidos = Apellido,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    TipoUsuario = tipousuario
                };

                await _usuarioHelper.AddUsuarioAsync(usuario, "123456");
                await _usuarioHelper.AddUsuarioToRoleAsync(usuario, tipousuario.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _usuarioHelper.CheckRoleAsync(TipoUsuario.Admin.ToString());
            await _usuarioHelper.CheckRoleAsync(TipoUsuario.Usuario.ToString());
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {


                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Alineación" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Lubricación de suspención delantera" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Lubricación de suspención trasera" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Frenos delanteros" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Frenos traseros" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Líquido frenos delanteros" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Líquido frenos traseros" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Calibración de válvulas" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Alineación carburador" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Aceite motor" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Aceite caja" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Filtro de aire" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Sistema eléctrico" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Guayas" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Cambio llanta delantera" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Cambio llanta trasera" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Reparación de motor" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Kit arrastre" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Banda transmisión" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Cambio batería" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Lavado sistema de inyección" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Lavada de tanque" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Cambio de bujia" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Cambio rodamiento delantero" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Cambio rodamiento trasero" });
                _context.Procedures.Add(new Procedure { Precio = 10000, Descripcion = "Accesorios" });
                await _context.SaveChangesAsync();
            }

        }

        private async Task CheckDocumentosAsync()
        {
            if (!_context.TipoDocumentos.Any())
            {


                _context.TipoDocumentos.Add(new TipoDocumento { Descripcion = "Cédula" });
                _context.TipoDocumentos.Add(new TipoDocumento { Descripcion = "DNI" });
                _context.TipoDocumentos.Add(new TipoDocumento { Descripcion = "NIT" });
                _context.TipoDocumentos.Add(new TipoDocumento { Descripcion = "Tarjeta de Identidad" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckMarcaAsync()
        {
            if (!_context.Marcas.Any())
            {


                _context.Marcas.Add(new Marca { Descripcion = "Ducati" });
                _context.Marcas.Add(new Marca { Descripcion = "Harley Davidson" });
                _context.Marcas.Add(new Marca { Descripcion = "KTM" });
                _context.Marcas.Add(new Marca { Descripcion = "Triumph" });
                _context.Marcas.Add(new Marca { Descripcion = "Suzuki" });
                _context.Marcas.Add(new Marca { Descripcion = "Kawasaky" });
                _context.Marcas.Add(new Marca { Descripcion = "TVS" });
                _context.Marcas.Add(new Marca { Descripcion = "Yamaha" });
                _context.Marcas.Add(new Marca { Descripcion = "Mazda" });
                _context.Marcas.Add(new Marca { Descripcion = "Chevrolet" });
                _context.Marcas.Add(new Marca { Descripcion = "Renault" });
                await _context.SaveChangesAsync();
            }

        }

        private async Task CheckTipoVehiculoAsync()
        {
            // Si no hay ningun tipo de vehiculo
            if (!_context.TipoVehiculos.Any())
            {
                _context.TipoVehiculos.Add(new TipoVehiculo { Descripcion = "Carro"});
                _context.TipoVehiculos.Add(new TipoVehiculo { Descripcion = "Moto"});
                //Guardamos los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
        }
    }
}
