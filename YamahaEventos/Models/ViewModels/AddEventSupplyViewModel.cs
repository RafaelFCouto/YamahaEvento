using System.ComponentModel.DataAnnotations;
using YamahaEventos.Models.Domain.Enum;

namespace YamahaEventos.Models.ViewModels
{
    public class AddEventSupplyViewModel
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid EventId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} não atende ao mínimo de {2} letras")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int TotalQuantity { get; set; }

        [Required]
        public int TotalPerParticipants { get; set; }

        [Required]
        public int TotalQuantityPerReceive { get; set; }

        [Required]
        public SupplyType SupplyType { get; set; }



    }
}
