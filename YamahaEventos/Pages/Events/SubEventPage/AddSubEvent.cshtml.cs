using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;
using YamahaEventos.Models.ViewModels;

namespace YamahaEventos.Pages.Events
{
    public class AddSubEventModel : PageModel
    {

        private readonly YamahaEventoDbContext _dbContext;

        public AddSubEventModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public AddSubEventViewModel AddSubEvent { get; set; }

        [BindProperty]
        public AddLocationViewModel AddLocation { get; set; }

        [FromRoute]
        public Guid Id { get; set; }

        public IActionResult OnPost([FromRoute] Guid id)
        {
            var evt = _dbContext.Event.Where(e => e.Id == id).FirstOrDefault();

            if (_dbContext == null)
                throw new Exception("Base de dados vazia");

            //Apenas para criação do ID do Sub Evento
            var SubEventDomainModel = new SubEvent()
            {
                Id = Guid.NewGuid(),
                EventId = evt.Id,
                Name = AddSubEvent.Name,
                Description = AddSubEvent.Description,
                DepartamentResponsible = AddSubEvent.DepartamentResponsible,
                AllowRepetition = AddSubEvent.AllowRepetition,
                
            };

            var LocationDomainModel = new LocationEvent()
            {
                Id = Guid.NewGuid(),
                LocationName = AddLocation.LocationName,
                SubEventId = SubEventDomainModel.Id,
                EventId = evt.Id
            };


            //Instancia de todas as informações
            SubEventDomainModel.LocationId = LocationDomainModel.Id;
            _dbContext.LocationEvent.Add(LocationDomainModel);
            _dbContext.SubEvent.Add(SubEventDomainModel);
            _dbContext.SaveChanges();


            return RedirectToPage("/Events/SubEventPage/AddSubEvent");
           
        }
    }
}
