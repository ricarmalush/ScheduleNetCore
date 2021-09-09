using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace ScheduleNetCore.Api.Application.Unit.Test.Stubs
{
    public static class TownStub
    {
        public static TownEntity townEntity1 = new()
        {
            ClientScheduleId = 1,
            ProvinceId = 1,
            Name = "Zuera",
            Low = true
        };

        public static TownEntity townEntity2 = new()
        {
            ClientScheduleId = 1,
            ProvinceId = 1,
            Name = "Villanueva",
            Low = true
        };

        public static List<TownEntity> townList = new List<TownEntity>(new TownEntity[] { townEntity1, townEntity2 });
    }
}
