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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ClientScheduleEntityConfig.SetEntityBuilder(modelBuilder.Entity<ClientScheduleEntity>());


            //Para que le devuelva el modelo a la base.
            base.OnModelCreating(modelBuilder);
        }
    }
}
