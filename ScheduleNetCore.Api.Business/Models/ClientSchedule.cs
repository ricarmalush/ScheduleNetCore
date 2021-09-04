using System;

namespace ScheduleNetCore.Api.Business.Models
{
    public class ClientSchedule
    {
        public string ClientName { get; set; }
        public DateTime? HighDate { get; set; }
        public DateTime? Lowdate { get; set; }
        public bool Low { get; set; }
    }
}
