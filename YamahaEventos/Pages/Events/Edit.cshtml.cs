using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain.Enum;
using YamahaEventos.Models.ViewModels;

namespace YamahaEventos.Pages.Events
{
    public class EditModel : PageModel
    {



        private readonly YamahaEventoDbContext _dbContext;

        public EditModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [BindProperty]
        public EditEventViewModel EditEventViewModel { get; set; }


        public void OnGet(Guid id)
        {
            var ev = _dbContext.Event.Find(id);
            if (ev != null)
            {
                EditEventViewModel = new EditEventViewModel()
                {

                    Id = ev.Id,
                    CodeEvent = ev.CodeEvent,
                    Name = ev.Name,
                    Description = ev.Description,
                    DepartamentResponsible = ev.DepartamentResponsible,
                    StartDate = ev.StartDate,
                    EndDate = ev.EndDate,
                    EventLocation = ev.EventLocation,

                };
            }
        }



        public void OnPost() 
        { 
            var existingEvent = _dbContext.Event.Find(EditEventViewModel.Id);

            if(existingEvent != null) 
            { 
                existingEvent.Name = EditEventViewModel.Name;
                existingEvent.Description = EditEventViewModel.Description;
                existingEvent.DepartamentResponsible = EditEventViewModel.DepartamentResponsible;
                existingEvent.EventLocation = EditEventViewModel.EventLocation;
                existingEvent.StartDate = EditEventViewModel.StartDate;
                existingEvent.EndDate = EditEventViewModel.EndDate;
            }

            _dbContext.SaveChanges();

            ViewData["Message"] = "Evento editado!";

        }

        public IActionResult OnPostDelete()
        {

            var existingEvent = _dbContext.Event.Find(EditEventViewModel.Id);

            if (existingEvent != null)
            {

                existingEvent.StatusEvent = EventStatus.Cancelado;
                _dbContext.SaveChanges();

                ViewData["Message"] = "Evento cancelado!";

                return RedirectToPage("/Events/List");
            }

            return RedirectToPage("Events/List");
        }
    }
}
