using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;
using YamahaEventos.Models.Domain.Enum;
using YamahaEventos.Models.ViewModels;

namespace YamahaEventos.Pages.Events
{
    public class AddModel : PageModel
    {


        private readonly YamahaEventoDbContext _dbContext;

        public AddModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private string generateEventCode()
        {

            int numEvent = _dbContext.Event.Count() + 1;

            string CodEvent = $"YEV{numEvent}";

            return CodEvent;


        }


        [BindProperty]
        public AddEventViewModel AddEventRequest { get; set; }


        public IActionResult OnPost()
        {


            if(_dbContext == null)
            {
                throw new Exception("dbContext is null");
            }

            var EventDomainModel = new Event
            {
                Id = Guid.NewGuid(),
                CodeEvent = generateEventCode(),
                Name = AddEventRequest.Name,
                Description = AddEventRequest.Description,
                DepartamentResponsible = AddEventRequest.DepartamentResponsible,
                EventLocation = AddEventRequest.EventLocation,
                StatusEvent = EventStatus.Planejado,
                StartDate = AddEventRequest.StartDate,
                EndDate = AddEventRequest.EndDate,
                LocationStatus = AddEventRequest.LocationStatus

            };

            _dbContext.Event.Add(EventDomainModel);
            _dbContext.SaveChanges();

            return RedirectToPage("/Events/Add");


            
        }
    }
}
