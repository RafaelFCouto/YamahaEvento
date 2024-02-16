using System.ComponentModel.DataAnnotations;

namespace YamahaEventos.Models.ViewModels
{
    public class EditLocationViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string LocationName { get; set; }

    }
}
