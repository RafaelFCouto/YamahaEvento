using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;
using YamahaEventos.Models.ViewModels;

namespace YamahaEventos.Pages.Events.SubEventPage
{
    public class EditSubEventModel : PageModel
    {

        private readonly YamahaEventoDbContext _dbContext;

        public EditSubEventModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [BindProperty]
        public EditSubEventViewModel EditSubEvent {get; set; }
        
        public Event Event { get; set; }

        public LocationEvent Location { get; set; }




        public void OnGet([FromRoute] Guid subEventId)
        {
            var subEvt = _dbContext.SubEvent.Find(subEventId);
            Location = _dbContext.LocationEvent.FirstOrDefault(l=> l.Id == subEvt.LocationId);
            Event = _dbContext.Event.FirstOrDefault(e => e.Id == subEvt.EventId);
            if (subEvt != null)
            {
                EditSubEvent = new EditSubEventViewModel()
                {
                    Id = subEvt.Id,
                    EventId = subEvt.EventId,
                    LocationId = subEvt.LocationId,
                    Name = subEvt.Name,
                    Description = subEvt.Description,
                    DepartamentResponsible = subEvt.DepartamentResponsible,
                    AllowRepetition = subEvt.AllowRepetition,


                };
            }
        }

        public void OnPost()
        {
            var existingSubEvent = _dbContext.SubEvent.Find(EditSubEvent.Id);
            
            if (existingSubEvent != null)
            {
                
                existingSubEvent.Name = EditSubEvent.Name;
                existingSubEvent.Description = EditSubEvent.Description;
                existingSubEvent.DepartamentResponsible = EditSubEvent.DepartamentResponsible;
                existingSubEvent.AllowRepetition = EditSubEvent.AllowRepetition;
                
            }

            _dbContext.SaveChanges();
            ViewData["Message"] = "Sub Evento editado!";

        }


        public IActionResult OnPostDelete()
        {

            var existingSubEvent = _dbContext.SubEvent.Find(EditSubEvent.Id);
            if (existingSubEvent != null)
            {
                var existingLocation = _dbContext.LocationEvent.Find(existingSubEvent.LocationId);
                if(existingLocation != null)
                {
                    _dbContext.LocationEvent.Remove(existingLocation);
                }
                _dbContext.SubEvent.Remove(existingSubEvent);
                _dbContext.SaveChanges();

                return RedirectToPage("/Events/List");
            }



            ViewData["Message"] = "Não funciona";
            return RedirectToPage("/Events/Add");

        }

    }
}
