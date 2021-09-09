using System.ComponentModel.DataAnnotations;

namespace ScheduleNetCore.Api.DataAccess.Contracts.Entities
{
    public class ProvinceEntity
    {
        [Key]
        public int ProvinceId { get; set; }
        public int CountryId { get; set; }
        public int ClientScheduleId { get; set; }
        public string Name { get; set; }
        public bool Low { get; set; }
    }
}
