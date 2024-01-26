using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.ViewModels;

namespace YamahaEventos.Pages.EventsSupply
{
    public class EditModel : PageModel
    {
        private readonly YamahaEventoDbContext _dbContext;

        public EditModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [FromRoute]
        public Guid EventId { get; set; }





        [BindProperty]
        public EditEventSupplyViewModel EditEventSupply { get; set; }



        public void OnGet(Guid id)
        {

            var supply = _dbContext.EventSupply.Find(id);

            if (supply != null)
            {
                EditEventSupply = new EditEventSupplyViewModel()
                {
                    Id = supply.Id,
                    EventId = supply.EventId,
                    Name = supply.Name,
                    Description = supply.Description,
                    TotalQuantity = supply.TotalQuantity,
                    TotalPerParticipants = supply.TotalPerParticipants,
                    TotalQuantityPerReceive = supply.TotalQuantityPerReceive,


                };
            }


        }

        public void OnPost()
        {

            var existingSupply = _dbContext.EventSupply.Find(EditEventSupply.Id);

            if (existingSupply != null)
            {
                existingSupply.Name = EditEventSupply.Name;
                existingSupply.Description = EditEventSupply.Description;
                existingSupply.TotalQuantity = EditEventSupply.TotalQuantity;
                existingSupply.TotalPerParticipants = EditEventSupply.TotalPerParticipants;
                existingSupply.TotalQuantityPerReceive = EditEventSupply.TotalQuantityPerReceive;
            }
            

            _dbContext.SaveChanges();

            ViewData["Message"] = "Item editado!";

        }


        public IActionResult OnPostDelete()
        {

            var existingSupply = _dbContext.EventSupply.Find(EditEventSupply.Id);

            if (existingSupply != null)
            {

                _dbContext.EventSupply.Remove(existingSupply);

                _dbContext.SaveChanges();

                ViewData["Message"] = "Item Removido!";

                return RedirectToPage($"/Events/List");
            }

            return RedirectToPage($"/Events/List");
        }
    }
}
