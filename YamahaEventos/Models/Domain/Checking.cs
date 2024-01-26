using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YamahaEventos.Models.Domain
{
    public class Checking
    {


        [Key]
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public double RfidCode { get; set; }
        public double Registration { get; set; }

        public DateTime CheckInTimes { get; set; }

        public string NameEmployee { get; set; }






    }
}
