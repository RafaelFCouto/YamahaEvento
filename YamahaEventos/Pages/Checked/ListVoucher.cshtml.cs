using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.Checked
{
    public class ListVoucherModel : PageModel
    {

        private readonly YamahaEventoDbContext _dbContext;

        public ListVoucherModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FromRoute]
        public Guid EventId { get; set; }

        public List<EventSupply> Supplies { get; set; }

        public void OnGet([FromRoute] Guid id)
        {
            Supplies = _dbContext.EventSupply.Where(c => c.EventId == id).ToList();

        }
    }
}
