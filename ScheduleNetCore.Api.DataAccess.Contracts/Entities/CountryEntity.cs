using System.ComponentModel.DataAnnotations;

namespace ScheduleNetCore.Api.DataAccess.Contracts.Entities
{
    public class CountryEntity
    {
        [Key]
        public int CountryId { get; set; }
        public int ClientScheduleId { get; set; }
        public string CountryName { get; set; }
        public bool Low { get; set; }

    }
}