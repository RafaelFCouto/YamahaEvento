using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YamahaEventos.Models.Domain.Enum;



namespace YamahaEventos.Models.Domain
{
    
    public class Organizer
    {


        [Key]
        [Required]
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
