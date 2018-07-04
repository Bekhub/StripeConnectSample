using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StripeConnectSampleServer.Models
{
    public class Payment
    {
        public string Token { get; set; }
        public decimal Amount { get; set; }
    }
}