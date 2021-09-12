using System.ComponentModel.DataAnnotations;

namespace ScheduleNetCore.Api.DataAccess.Contracts.Entities
{
    public class CenterEntity
    {
        [Key]
        public int CenterId { get; set; }
        public int ClientScheduleId { get; set; }
        public string CenterName { get; set; }
        public bool Low { get; set; }
    }
}
