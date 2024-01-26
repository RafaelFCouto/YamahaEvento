using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.Checked
{
    public class CheckInModel : PageModel
    {

        private readonly YamahaEventoDbContext _dbContext;

        public CheckInModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Employee Employee { get; set; }


       


        public void OnGet()
        {

            


        }

        public void OnPost(double RfidCode, [FromRoute] Guid id)
        {

            
            var emp = _dbContext.Employee.Where(e => e.RfidCode == RfidCode).FirstOrDefault();

            if (emp != null)
            {

                Employee = emp;

            }
            else 
            {
                Employee = new Employee()
                {
                    Name = "N�o encontrado",
                    NameDepartament = "N�o encontrado",
                    Position = "N�o encontrado"

                };

            
            
            }
            

            bool validation = _dbContext.Checking.Any(e => e.RfidCode == RfidCode && e.EventId == id);
            

            if (validation)
            {
                ViewData["Message"] = "O registro j� foi realizado!";
                // TypeMessage: Se acontecer algum problema == Erro / Se der certo == null
                ViewData["TypeMessage"] = "error";
            }
            else if (emp == null)
            {
                ViewData["Message"] = "Usu�rio n�o cadastrado, procure a organiza��o";
                ViewData["TypeMessage"] = "error";
            }
            else if (emp.StatusEmployee != "Trabalhando")
            {
                ViewData["Message"] = $"Colaborador n�o permitido por estar em situa��o de {emp.StatusEmployee}, procure a Organiza��o";
                ViewData["TypeMessage"] = "error";
            }
            else
            {
                var check = new Checking()
                {
                    Id = new Guid(),
                    EventId = id,
                    RfidCode = RfidCode,
                    CheckInTimes = DateTime.Now,
                    NameEmployee = emp.Name,
                    Registration = emp.Registration


                };

                _dbContext.Checking.Add(check);
                _dbContext.SaveChanges();

                ViewData["Message"] = "Registro realizado!";
                ViewData["TypeMessage"] = null;
            }

            
          
            
        }




    }
}
