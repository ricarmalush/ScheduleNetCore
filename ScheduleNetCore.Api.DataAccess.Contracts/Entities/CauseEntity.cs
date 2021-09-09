using System.ComponentModel.DataAnnotations;

namespace ScheduleNetCore.Api.DataAccess.Contracts.Entities
{
    public class CauseEntity
    {
        [Key]
        public int CauseId { get; set; }
        public int ClientScheduleId { get; set; }
        public string CauseName { get; set; }
        public bool Low { get; set; }
    }
}
