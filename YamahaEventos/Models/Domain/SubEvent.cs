using System.ComponentModel.DataAnnotations;
using YamahaEventos.Models.Domain.Enum;

namespace YamahaEventos.Models.Domain
{
    public class SubEvent
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EventId { get; set; }

        [Required]
        public Guid LocationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DepartamentResponsible { get; set; }

        [Required]
        public EventRepetition AllowRepetition { get; set; }
    }
}
