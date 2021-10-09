using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data.Entities;

namespace Taller_Mecanico.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TipoVehiculo> TipoVehiculos{ get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoVehiculo>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<Marca>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<TipoDocumento>().HasIndex(x => x.Descripcion).IsUnique();
        }
    }
}
