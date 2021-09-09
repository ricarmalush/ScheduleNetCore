using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleNetCore.Api.DataAccess.Contracts.Entities
{
    public class ClientScheduleEntity
    {
        [Key]
        public int ClientScheduleId { get; set; }
        public string ClientName { get; set; }
        public DateTime? HighDate { get; set; }
        public DateTime? Lowdate { get; set; }
        public bool Low { get; set; }
    }
}