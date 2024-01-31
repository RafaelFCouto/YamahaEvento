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



        public void OnPost(double rfidCode, [FromRoute] Guid eventId, [FromRoute] Guid supplyId)
        {

            var emp = _dbContext.Employee.Where(e => e.RfidCode == rfidCode).FirstOrDefault();
            var supply = _dbContext.EventSupply.Where(s => s.Id == supplyId).FirstOrDefault();
            var qtdSupply = _dbContext.DeliverySupply.Where(e=>e.RfidCode==rfidCode && e.SupplyId==supplyId).Count();
            var evt = _dbContext.Event.Where(e => e.Id == eventId).FirstOrDefault();


            
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
                    Id = new Guid(),
                    EventId = evt.Id,
                    SupplyId = supply.Id,
                    RfidCode = rfidCode,
                    Registration = emp.Registration,
                    Name = emp.Name,
                    DeliveredDateTime = DateTime.Now,

                };

                _dbContext.DeliverySupply.Add(delivered);
                _dbContext.SaveChanges();


                ViewData["Message"] = "Retirada Realizada com sucesso!";
                ViewData["TypeMessage"] = null;
            }





        }
            

         


    }
}
