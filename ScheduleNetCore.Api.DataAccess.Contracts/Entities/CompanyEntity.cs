using System.ComponentModel.DataAnnotations;

namespace ScheduleNetCore.Api.DataAccess.Contracts.Entities
{
    public class CompanyEntity
    {
        [Key]
        public int CompanyId { get; set; }
        public int ClientScheduleId { get; set; }
        public int TownId { get; set; }
        public string CompanyName { get; set; }
        public bool Low { get; set; }
    }
}
