using System.ComponentModel.DataAnnotations;

namespace YamahaEventos.Models.ViewModels
{
    public class EditEmployeeViewModel
    {
        [Key]
        public double RfidCode { get; set; }
        public double Registration { get; set; }
        public string Name { get; set; }
        public string TypeEmployee { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string CodeDepartament { get; set; }
        public string NameDepartament { get; set; }
        public string StatusEmployee { get; set; }
    }
}
