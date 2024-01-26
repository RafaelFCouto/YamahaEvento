using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;
using YamahaEventos.Models.ViewModels;

namespace YamahaEventos.Pages.Events
{
    public class AddOrganizerModel : PageModel
    {

        private readonly YamahaEventoDbContext _dbContext;

        public AddOrganizerModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Organizer> Organizers { get; set; }

        public AddOrganizerViewModel AddOrganizerViewModel { get; set; }
        public EditEventViewModel EditEventViewModel { get; set; }




       






    }
}
