using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;

namespace ScheduleNetCore.Api.DataAccess.EntityConfig
{
    public class CenterEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CenterEntity> entityBuilder)
        {
            entityBuilder.ToTable("Center");
            entityBuilder.HasKey(x => x.CenterId);
            entityBuilder.Property(x => x.CenterId).IsRequired();
        }
    }
}
