using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRulesController : ControllerBase
    {
        DataContext context = null;
        public PaymentRulesController(DataContext _obj)
        {
            context = _obj;
        }


        [HttpGet]
        public List<PaymentRules> GetPaymentRules()
        {
            try
            {
                var listPayment = context.paymentRules.ToList();
                return listPayment;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult InsertPaymentRules(PaymentRules pay)
        {
            try
            {
                pay.PaymentTime= DateTime.Now;
               
                
                context.paymentRules.Add(pay);

                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "inserted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut]

        public ActionResult UpdatePayment(PaymentRules pay)
        {

            try
            {
                //pay.PaymentTime = DateTime.Now;
                var Pay = context.paymentRules.FirstOrDefault();
                Pay.PaymentType = pay.PaymentType;
                Pay.Amount = pay.Amount;
                Pay.PaymentTime = Pay.PaymentTime;
              


                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "updated Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{PaymentId}")]
        public ActionResult DeletePayment(int PaymentId)
        {
            try
            {
                var pay = context.paymentRules.Where(x => x.PaymentId == PaymentId).First();
                context.Remove(pay);
                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "deleted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{PaymentId}")]
        public PaymentRules getPaymentById(int PaymentId)
        {
            try
            {
                var pay = context.paymentRules.Where(x => x.PaymentId == PaymentId).First();
                return pay;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
