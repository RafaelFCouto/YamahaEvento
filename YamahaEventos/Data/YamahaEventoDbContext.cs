using Microsoft.EntityFrameworkCore;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Data
{
    public class YamahaEventoDbContext : DbContext
    {
        public YamahaEventoDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Event> Event { get; set; }

        public DbSet<Organizer> Organizer { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Checking> Checking { get; set; }

        public DbSet<EventSupply> EventSupply { get; set; }

        public DbSet<DeliverySupply> DeliverySupply { get; set; }   
        







    }
}
