using ScheduleNetCore.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ScheduleNetCore.Api.Application.Unit.Test.Stubs
{
    public static class ClientScheduleStub
    {
        public static ClientScheduleEntity clientScheduleEntity1 = new()
        {
            ClientName = "FibraPlas Aragón S.L",
            HighDate = DateTime.Now,
            Lowdate = DateTime.Now,
            Low = true
        };

        public static ClientScheduleEntity clientScheduleEntity2 = new()
        {
            ClientName = "Ecomputer S.L",
            HighDate = DateTime.Now,
            Lowdate = DateTime.Now,
            Low = true
        };

        public static List<ClientScheduleEntity> clientScheduleList = new List<ClientScheduleEntity>(new ClientScheduleEntity[] { clientScheduleEntity1, clientScheduleEntity2 });
    }
}
