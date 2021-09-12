using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace ScheduleNetCore.Api.Application.Unit.Test.Stubs
{
    public static class CenterStub
    {
        public static CenterEntity centerEntity1 = new()
        {
            ClientScheduleId = 1,
            CenterId = 1,
            CenterName = "Zaragoza",
            Low = true
        };

        public static CenterEntity centerEntity2 = new()
        {
            ClientScheduleId = 1,
            CenterId = 1,
            CenterName = "Huesca",
            Low = true
        };

        public static List<CenterEntity> centerList = new List<CenterEntity>(new CenterEntity[] { centerEntity1, centerEntity2 });
    }
}
