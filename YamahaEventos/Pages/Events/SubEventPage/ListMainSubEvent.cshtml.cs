using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.Events.SubEventPage
{
    public class ListMainSubEventModel : PageModel
    {


        private readonly YamahaEventoDbContext _dbContext;

        public ListMainSubEventModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [FromRoute]
        public Guid EventId { get; set; }

        public List<SubEvent> SubEvents { get; set; }
        public List<LocationEvent> Locations { get; set; }

        public void OnGet([FromRoute] Guid eventId)
        {
            SubEvents = _dbContext.SubEvent.Where(e=>e.EventId == eventId).ToList();
            Locations = _dbContext.LocationEvent.Where(e => e.EventId == eventId).ToList();
        }
    }
}
