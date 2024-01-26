using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using YamahaEventos.Models.Domain.Enum;

namespace YamahaEventos.Models.ViewModels
{
    public class AddOrganizerViewModel
    {
        
        [Required]
        [StringLength(10, ErrorMessage = "{0} ultrapassou o número máximo permitido {1}")]
        public string Registration { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Departament { get; set; }

        [Required]
        // 1 = Organizador || 2 = Staff
        public OrganizerType OrganizerType { get; set; }
    }
}
