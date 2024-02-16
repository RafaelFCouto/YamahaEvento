using System.ComponentModel.DataAnnotations;

namespace YamahaEventos.Models.Domain
{
    public class LocationEvent
    {
        [Key]
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public Guid SubEventId { get; set; }

        [Required]
        public string LocationName { get; set; }

    }
}
