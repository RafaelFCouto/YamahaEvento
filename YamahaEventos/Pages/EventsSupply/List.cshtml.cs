using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.EventsSupply
{
    public class ListModel : PageModel
    {


        private readonly YamahaEventoDbContext _dbContext;

        public ListModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [FromRoute]
        public Guid Id { get; set; }

        public List<EventSupply> Supplies { get; set; }

        public void OnGet([FromRoute] Guid id)
        {
            Supplies = _dbContext.EventSupply.Where(c=> c.EventId == id).ToList();

        }
    }
}
