using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stripe;
using Xamarin.Forms;

namespace StripeConnectSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Pay();
        }
        public async Task Pay()
        {
            var token = CreateToken(cardNumber.Text, expireDate.Date.Month.ToString(), expireDate.Date.Year.ToString(), cVV.Text);
            HttpClient client = new HttpClient();
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync("http://localhost:57144/api/payment",
                                    new StringContent(JsonConvert.SerializeObject(new Payment()
                                    {
                                        Amount = 80.56M,
                                        Token = token
                                    }),


                                                      Encoding.UTF8,
                                                      "application/json"));
            }
            catch (Exception r)
            {

                throw;
            }

            resultLabel.Text = response.IsSuccessStatusCode ? "success" : "failed";
        }
        public string CreateToken(string cardNumber, string cardExpMonth, string cardExpYear, string cardCVC)
        {
            StripeConfiguration.SetApiKey("public key");

            var tokenOptions = new StripeTokenCreateOptions()
            {
                Card = new StripeCreditCardOptions()
                {
                    Number = cardNumber,
                    ExpirationYear = int.Parse(cardExpYear),
                    ExpirationMonth = int.Parse(cardExpMonth),
                    Cvc = cardCVC
                }
            };

            var tokenService = new StripeTokenService();
            StripeToken stripeToken = tokenService.Create(tokenOptions);

            return stripeToken.Id; // This is the token
        }
    }
}