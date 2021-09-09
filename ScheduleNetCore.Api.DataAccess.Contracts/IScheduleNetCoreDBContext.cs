using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.DataAccess.Contracts
{
    public interface IScheduleNetCoreDBContext
    {
        public DbSet<ClientScheduleEntity> ClientSchedule { get; set; }
        public DbSet<CountryEntity> Country { get; set; }
        public DbSet<ProvinceEntity> Province { get; set; }
        public DbSet<TownEntity> Town { get; set; }
        public DbSet<CompanyEntity> Company { get; set; }
        public DbSet<CauseEntity> Cause { get; set; }

        //Estas son las operaciones básicas que realiza el contexto
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);
    }
}
