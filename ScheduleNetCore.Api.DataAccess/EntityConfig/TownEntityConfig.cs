using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;

namespace ScheduleNetCore.Api.DataAccess.EntityConfig
{
    public class TownEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<TownEntity> entityBuilder)
        {
            entityBuilder.ToTable("Town");
            entityBuilder.HasKey(x => x.TownId);
            entityBuilder.Property(x => x.TownId).IsRequired();
        }
    }
}
