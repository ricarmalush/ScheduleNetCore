using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace ScheduleNetCore.Api.Application.Unit.Test.Stubs
{
    public static class ProvinceStub
    {
        public static ProvinceEntity provinceEntity1 = new()
        {
            ClientScheduleId = 1,
            CountryId = 1,
            Name = "Zaragoza",
            Low = true
        };

        public static ProvinceEntity provinceEntity2 = new()
        {
            ClientScheduleId = 1,
            CountryId = 1,
            Name = "Huesca",
            Low = true
        };

        public static List<ProvinceEntity> clientScheduleList = new List<ProvinceEntity>(new ProvinceEntity[] { provinceEntity1, provinceEntity2 });
    }
}
