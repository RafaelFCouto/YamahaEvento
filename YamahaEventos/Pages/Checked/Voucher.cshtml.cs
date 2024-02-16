using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YamahaEventos.Data;
using YamahaEventos.Models.Domain;

namespace YamahaEventos.Pages.Checked
{
    public class VoucherModel : PageModel
    {

        

        private readonly YamahaEventoDbContext _dbContext;

        public VoucherModel(YamahaEventoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FromRoute]
        public Guid EventId { get; set; }


        public void OnPost(double rfidCode, [FromRoute] Guid eventId, [FromRoute] Guid supplyId)
        {

            var emp = _dbContext.Employee.FirstOrDefault(e => e.RfidCode == rfidCode);
            var supply = _dbContext.EventSupply.FirstOrDefault(s => s.Id == supplyId);
            var qtdSupply = _dbContext.DeliverySupply.Count(e => e.RfidCode == rfidCode && e.SupplyId == supplyId);
            var evt = _dbContext.Event.FirstOrDefault(e => e.Id == eventId);


            
            if(qtdSupply == supply.TotalPerParticipants )
            {

                ViewData["Message"] = "Você já retirou esse item";
                ViewData["TypeMessage"] = "Error";
            }
            else if (evt.LocationStatus==0 && !(_dbContext.Checking.Any(e => e.RfidCode == rfidCode)))
            {
               
                ViewData["Message"] = "O Colaborador não realizou o check-in";
                ViewData["TypeMessage"] = "Error";
                
            }
            else
            {


                var delivered = new DeliverySupply()
                {
                    Id = Guid.NewGuid(),
                    SupplyId = supply.Id,
                    EventId = evt.Id,
                    RfidCode = emp.RfidCode,
                    Registration = emp.Registration,
                    Name = emp.Name,
                    DeliveredDateTime = DateTime.Now,

                };

    

                _dbContext.DeliverySupply.Add(delivered);
                _dbContext.SaveChanges();


                ViewData["Message"] = "Retirada Realizada com sucesso!";
                ViewData["TypeMessage"] = null;
                ViewData["Name"] = emp.Name;
                ViewData["Position"] = emp.Position;
                ViewData["Departament"] = emp.NameDepartament;
            }





        }
            

         


    }
}
