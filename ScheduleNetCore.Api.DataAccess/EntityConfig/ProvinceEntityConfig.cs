using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;

namespace ScheduleNetCore.Api.DataAccess.EntityConfig
{
    public class ProvinceEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ProvinceEntity> entityBuilder)
        {
            entityBuilder.ToTable("Province");
            entityBuilder.HasKey(x => x.ProvinceId);
            entityBuilder.Property(x => x.ProvinceId).IsRequired();
        }
    }
}
