using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace ScheduleNetCore.Api.Application.Unit.Test.Stubs
{
    public static class CompanyStub
    {
        public static CompanyEntity companyEntity1 = new()
        {
            ClientScheduleId = 1,
            CompanyId = 1,
            TownId =1,
            CompanyName = "AytoZaragoza",
            Low = true
        };

        public static CompanyEntity companyEntity2 = new()
        {
            ClientScheduleId = 1,
            CompanyId = 1,
            TownId = 1,
            CompanyName = "AytoHuesca",
            Low = true
        };

        public static List<CompanyEntity> companyList = new List<CompanyEntity>(new CompanyEntity[] { companyEntity1, companyEntity2 });
    }
}
