using System;
using System.Collections.Generic;
using System.Text;

namespace StripeConnectSample
{
    public class Payment
    {
        public string Token { get; set; }
        public decimal Amount { get; set; }
    }
}
