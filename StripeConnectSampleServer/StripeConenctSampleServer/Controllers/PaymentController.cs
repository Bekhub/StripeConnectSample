using Stripe;
using StripeConnectSampleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StripeConnectSampleServer.Controllers
{
    public class PaymentController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody]Payment payment)
        {
            var charge = new StripeChargeCreateOptions
            {         
                Amount = Convert.ToInt32(payment.Amount * 100), 
                Currency = "usd",
                Description = "something awesome",
                SourceTokenOrExistingSourceId = payment.Token
            };

            var service = new StripeChargeService("sekret_key");

            try
            {
                var response = service.Create(charge);

            }
            catch (StripeException ex)
            {
                StripeError stripeError = ex.StripeError;
            }

            return Ok(true);
        }
    }
}
