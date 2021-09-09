using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;

namespace ScheduleNetCore.Api.DataAccess.EntityConfig
{
    public class CountryEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CountryEntity> entityBuilder)
        {
            entityBuilder.ToTable("Country");
            entityBuilder.HasKey(x => x.CountryId);
            entityBuilder.Property(x => x.CountryId).IsRequired();
        }
    }
}
