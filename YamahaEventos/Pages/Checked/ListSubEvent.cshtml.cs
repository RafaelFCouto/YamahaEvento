using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.Checked
{
    public class ListSubEventModel : PageModel
    {
        private readonly YamahaEventoDbContext _dbContext;

        public ListSubEventModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FromRoute]
        public Guid EventId { get; set; }

        public List <SubEvent> SubEvents { get; set; }
        
        public List<LocationEvent>  Location { get; set; }
        
        

        public void OnGet([FromRoute] Guid eventId)
        {
            SubEvents = _dbContext.SubEvent.Where(e => e.EventId == eventId).ToList();
            Location = _dbContext.LocationEvent.Where(e=> e.EventId == eventId).ToList();
        }

        
    }
}
