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

        [FromRoute]
        public Guid EventId { get; set; }

     

      

        public void OnPost(double RfidCode, [FromRoute] Guid subEventId)
        {

            
            var emp = _dbContext.Employee.Where(e => e.RfidCode == RfidCode).FirstOrDefault();
            var subEvt = _dbContext.SubEvent.Where(e=> e.Id == subEventId).FirstOrDefault();
            bool validation = _dbContext.Checking.Any(e => e.RfidCode == RfidCode && e.SubEventId == subEventId);


            if(validation && (int)subEvt.AllowRepetition == 0)
            {
                
                
                ViewData["Message"] = "O registro já foi realizado!";
                // TypeMessage: Se acontecer algum problema == Erro / Se der certo == null
                ViewData["TypeMessage"] = "error";
                

            }
            else if (emp == null)
            {
                ViewData["Message"] = "Usuário não cadastrado, procure a organização";
                ViewData["TypeMessage"] = "error";
            }
            else if (emp.StatusEmployee != "Trabalhando")
            {
                ViewData["Message"] = $"Colaborador não permitido por estar em situação de {emp.StatusEmployee}, procure a Organização";
                ViewData["TypeMessage"] = "error";
            }
            else
            {
                var check = new Checking()
                {
                    Id = new Guid(),
                    SubEventId = subEvt.Id,
                    RfidCode = emp.RfidCode,
                    CheckInTimes = DateTime.Now,
                    NameEmployee = emp.Name,
                    Registration = emp.Registration


                };

                _dbContext.Checking.Add(check);
                _dbContext.SaveChanges();

                ViewData["Message"] = "Registro realizado!";
                ViewData["TypeMessage"] = null;
                ViewData["Name"] = emp.Name;
                ViewData["Position"] = emp.Position;
                ViewData["Departament"] = emp.NameDepartament;

            }

            
          
            
        }




    }
}
