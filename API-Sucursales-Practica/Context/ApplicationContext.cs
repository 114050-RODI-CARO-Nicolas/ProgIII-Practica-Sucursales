using API_Sucursales_Practica.Domain;
using Microsoft.EntityFrameworkCore;
using Practica_API_Sucursales.Domain;

namespace API_Sucursales_Practica.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<SucursalEntity> Sucursales { get; set; }
        public DbSet<TipoEntity> Tipos { get; set; }
        public DbSet<ProvinciaEntity> Provincias { get; set; }
        public DbSet<ConfiguracionEntity> Configuraciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProvinciaEntity>().HasData(
                new ProvinciaEntity { Id = Guid.NewGuid(), Nombre = "Buenos Aires" },
                new ProvinciaEntity { Id = Guid.NewGuid(), Nombre = "Cordoba" },
                new ProvinciaEntity { Id = Guid.NewGuid(), Nombre = "Santa Fe" }
                );

            modelBuilder.Entity<TipoEntity>().HasData(
                new TipoEntity { Id = Guid.NewGuid(), Nombre="Pequeña" },
                new TipoEntity { Id = Guid.NewGuid(), Nombre="Grande" }
                );

            modelBuilder.Entity<ConfiguracionEntity>().HasData(
               new ConfiguracionEntity { Id = Guid.NewGuid(), Nombre="padding-top", Valor="50px" },
                 new ConfiguracionEntity { Id = Guid.NewGuid(), Nombre="padding-left", Valor="100px" }
               );



        }

    }
}
