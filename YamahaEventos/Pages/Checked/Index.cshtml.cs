using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.Checked
{
    public class IndexModel : PageModel
    {
        private readonly YamahaEventoDbContext _dbContext;

        public IndexModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FromRoute]
        public Guid Id { get; set; }


        public List<EventSupply> Supplies { get; set; }

        public void OnGet()
        {
            Supplies = _dbContext.EventSupply.Where(e=> e.EventId == Id).ToList();
        }
    }
}
