using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace ScheduleNetCore.Api.Application.Unit.Test.Stubs
{
    public static class CauseStub
    {
        public static CauseEntity causeEntity1 = new()
        {
            ClientScheduleId = 1,
            CauseId = 1,
            CauseName = "Enfermedad",
            Low = true
        };

        public static CauseEntity causeEntity2 = new()
        {
            ClientScheduleId = 1,
            CauseId = 1,
            CauseName = "Médico",
            Low = true
        };

        public static List<CauseEntity> causeList = new List<CauseEntity>(new CauseEntity[] { causeEntity1, causeEntity2 });
    }
}
