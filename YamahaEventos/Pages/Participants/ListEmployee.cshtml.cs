using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.Participants
{
    public class ListEmployeeModel : PageModel
    {

        private readonly YamahaEventoDbContext _dbContext;

        public ListEmployeeModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Employee> Employees { get; set; }

        public void OnGet()
        {
            Employees = _dbContext.Employee.ToList();
        }
    }
}
