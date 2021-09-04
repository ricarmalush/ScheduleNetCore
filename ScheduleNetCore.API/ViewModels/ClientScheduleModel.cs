using System;

namespace ScheduleNetCore.API.ViewModels
{
    public class ClientScheduleModel
    {
        public string ClientName { get; set; }
        public DateTime? HighDate { get; set; }
        public DateTime? Lowdate { get; set; }
        public bool Low { get; set; }
    }
}
