namespace YamahaEventos.Models.Domain
{
    public class DeliverySupply
    {
        public Guid Id {get; set; }
        public Guid EventId { get; set; }
        public Guid SupplyId { get; set; }
        public double RfidCode { get; set; }
        public double Registration { get; set; }
        public string Name { get; set; }
        public DateTime DeliveredDateTime { get; set; }




    }
}
