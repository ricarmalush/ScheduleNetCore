using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleNetCore.Api.DataAccess.Contracts.Entities;

namespace ScheduleNetCore.Api.DataAccess.EntityConfig
{
    public class CompanyEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CompanyEntity> entityBuilder)
        {
            entityBuilder.ToTable("Company");
            entityBuilder.HasKey(x => x.CompanyId);
            entityBuilder.Property(x => x.CompanyId).IsRequired();
        }
    }
}
