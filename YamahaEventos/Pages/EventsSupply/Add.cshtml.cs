using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.ViewModels;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.EventsSupply
{
    public class AddModel : PageModel
    {

        private readonly YamahaEventoDbContext _dbContext;

        public AddModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public AddEventSupplyViewModel AddEventSupply {  get; set; }   



        public void OnGet()
        {
        }

        public IActionResult OnPost([FromRoute] Guid id) {

            var supply = new EventSupply()
            {
                Id = new Guid(),
                EventId = id,
                Name = AddEventSupply.Name,
                Description = AddEventSupply.Description,
                TotalQuantity = AddEventSupply.TotalQuantity,
                TotalPerParticipants = AddEventSupply.TotalPerParticipants,
                TotalQuantityPerReceive = AddEventSupply.TotalQuantityPerReceive,
                SupplyType = AddEventSupply.SupplyType,
                   

            };

            _dbContext.EventSupply.Add(supply);
            _dbContext.SaveChanges();

            return RedirectToPage("/EventsSupply/Add");

        
            
        
        
        
        }
    }
}
