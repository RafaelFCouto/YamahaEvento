using System.ComponentModel.DataAnnotations;
using YamahaEventos.Models.Domain.Enum;

namespace YamahaEventos.Models.ViewModels
{
    public class AddEventViewModel
    {
        [Required]
        public Guid Guid { get; set; }

        //Esta informação será tratada diretamente na página de cadastro para que seja possível realizar a população da base de dados e realizar o incremento.
        //public string CodeEvent { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} não atende ao mínimo de {2} letras")]
        public string Name { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "{0} ultrapassou o máximo permitido de {1} letras ")]
        public string Description { get; set; }

        [Required]
        public string DepartamentResponsible { get; set; }

        [Required]
        public string EventLocation { get; set; }

        [Required]
        public EventStatus StatusEvent { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        [Required]
        public LocationStatus LocationStatus { get; set; }
    }
}
