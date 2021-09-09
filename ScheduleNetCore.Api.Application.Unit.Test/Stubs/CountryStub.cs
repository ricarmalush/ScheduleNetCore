using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace ScheduleNetCore.Api.Application.Unit.Test.Stubs
{
    public static class CountryStub
    {
        public static CountryEntity countryEntity1 = new()
        {
            ClientScheduleId = 1,
            CountryName = "España",
            Low = true
        };

        public static CountryEntity countryEntity2 = new()
        {
            ClientScheduleId = 2,
            CountryName = "Francia",
            Low = true
        };

        public static List<CountryEntity> clientScheduleList = new List<CountryEntity>(new CountryEntity[] { countryEntity1, countryEntity2 });
    }
}
