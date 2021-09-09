using Microsoft.EntityFrameworkCore;
using ScheduleNetCore.Api.DataAccess.Contracts;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using ScheduleNetCore.Api.DataAccess.EntityConfig;

namespace ScheduleNetCore.Api.DataAccess
{
    public class ScheduleNetCoreDBContext : DbContext, IScheduleNetCoreDBContext
    {
        //Este constructor se hace por que algunas veces cuando se instancia el DbContext la aplicación
        //Necesita tener un constructor en el cual se le pasa el DbContextOptions para poder instanciar
        //El contexto.
        public ScheduleNetCoreDBContext(DbContextOptions<ScheduleNetCoreDBContext> contextOptions)
        : base(contextOptions)
        {
        }

        public DbSet<ClientScheduleEntity> ClientSchedule { get; set; }
        public DbSet<CountryEntity> Country { get; set; }
        public DbSet<ProvinceEntity> Province { get; set; }
        public DbSet<TownEntity> Town { get; set; }
        public DbSet<CompanyEntity> Company { get; set; }
        public DbSet<CauseEntity> Cause { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ClientScheduleEntityConfig.SetEntityBuilder(modelBuilder.Entity<ClientScheduleEntity>());
            CountryEntityConfig.SetEntityBuilder(modelBuilder.Entity<CountryEntity>());
            ProvinceEntityConfig.SetEntityBuilder(modelBuilder.Entity<ProvinceEntity>());
            TownEntityConfig.SetEntityBuilder(modelBuilder.Entity<TownEntity>());
            CompanyEntityConfig.SetEntityBuilder(modelBuilder.Entity<CompanyEntity>());
            CauseEntityConfig.SetEntityBuilder(modelBuilder.Entity<CauseEntity>());

            //Para que le devuelva el modelo a la base.
            base.OnModelCreating(modelBuilder);
        }
    }
}
