using System.ComponentModel.DataAnnotations;

namespace ScheduleNetCore.Api.DataAccess.Contracts.Entities
{
    public class TownEntity
    {
        [Key]
        public int TownId { get; set; }
        public int ProvinceId { get; set; }
        public int ClientScheduleId { get; set; }
        public string Name { get; set; }
        public bool Low { get; set; }
    }
}
