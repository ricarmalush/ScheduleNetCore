using ScheduleNetCore.Api.Business.Models;
using ScheduleNetCore.API.ViewModels;
using System;

namespace ScheduleNetCore.API.Mappers
{
    public static class ClientScheduleMapper
    {
        public static ClientSchedule Map(ClientScheduleModel model)
        {
            return new ClientSchedule()
            {
                ClientName = model.ClientName,
                HighDate = DateTime.Now,
                Lowdate = DateTime.Now,
                Low = model.Low
            };
        }
    }
}
