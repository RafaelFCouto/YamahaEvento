using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;
using YamahaEventos.Models.ViewModels;

namespace YamahaEventos.Pages.Events
{
    public class ListModel : PageModel
    {

        private readonly YamahaEventoDbContext _dbContext;


        public List<Event> Evts { get; set; }
        public ListModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Evts = _dbContext.Event.ToList();
        }



    }



}
