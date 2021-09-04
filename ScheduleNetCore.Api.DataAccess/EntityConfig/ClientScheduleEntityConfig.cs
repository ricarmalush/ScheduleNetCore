using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;

namespace ScheduleNetCore.Api.DataAccess.EntityConfig
{
    public class ClientScheduleEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ClientScheduleEntity> entityBuilder)
        {
            entityBuilder.ToTable("ClientSchedule");
            entityBuilder.HasKey(x => x.ClientScheduleId);
            entityBuilder.Property(x => x.ClientScheduleId).IsRequired();
        }
    }
}
