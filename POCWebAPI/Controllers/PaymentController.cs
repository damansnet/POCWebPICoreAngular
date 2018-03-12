using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace POCWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Payment")]
    public class PaymentController : Controller
    {

        private readonly IPaymentService _PaymentService;
        public PaymentController(IPaymentService PaymentService)
        {

            _PaymentService = PaymentService;

        }

        [HttpGet]
        public string Get()
        {
            //

            return "O.K";


        }
        [EnableCors("CorsPolicy")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Payment Payment)
        {
            //

            System.Diagnostics.Debug.Print(Payment.ToString());


            if(ModelState.IsValid)
            {
                Operation opr= _PaymentService.AddPayment(Payment);
                if(opr.ErrorMessage!="")
                {

                    //there is some error here...:(
                    return NotFound(opr);
                }
                else
                {

                    return Ok(opr);
                }
            }
            else
            {
                Operation oprInvalid = new Operation() { EntityId=-1, ErrorMessage="Invalid Input", OperationStatus=Constants.OperationStatus.NotSuccessful };
                Response.Headers.Add("Error","Invalid input");
                return BadRequest(ModelState);
                //return NotFound(oprInvalid);
            }

        }

    }
}