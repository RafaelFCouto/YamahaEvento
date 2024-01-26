using System.ComponentModel.DataAnnotations;
using YamahaEventos.Models.Domain.Enum;

namespace YamahaEventos.Models.Domain
{
    public class Voucher
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid EventId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        //Quantidade de itens que o evento tem Ex.: 5000 águas
        public int TotalQuantity { get; set; }

        [Required]
        //Quantidade que cada colaborador pode retirar
        public int TotalPerParticipants { get; set; }

        [Required]
        //Quantidade que o colaborador vai retirar por vez Ex.: Cada Retirada consome 2 águas
        public int TotalQuantityPerReceive { get; set; }

        [Required]
        //A quantidade total que foi entregue daquele item
        public int TotalDelivered { get; set; }

        [Required]
        //Se vai ser Brinde ou Consumivel Ex.: Água = Consumível e Camisa = Brinde
        public SupplyType SupplyType { get; set; }



    }
}
