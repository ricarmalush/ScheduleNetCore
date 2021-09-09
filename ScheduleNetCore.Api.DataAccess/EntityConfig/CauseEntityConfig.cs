using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;

namespace ScheduleNetCore.Api.DataAccess.EntityConfig
{
    public class CauseEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CauseEntity> entityBuilder)
        {
            entityBuilder.ToTable("Cause");
            entityBuilder.HasKey(x => x.CauseId);
            entityBuilder.Property(x => x.CauseId).IsRequired();
        }
    }
}
