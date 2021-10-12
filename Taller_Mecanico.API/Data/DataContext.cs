using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data.Entities;

namespace Taller_Mecanico.API.Data
{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TipoVehiculo> TipoVehiculos{ get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<VehiculoFoto> VehiculoFotos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoVehiculo>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Marca>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<TipoDocumento>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Vehiculo>().HasIndex(x => x.Placa).IsUnique();
        }
    }
}
