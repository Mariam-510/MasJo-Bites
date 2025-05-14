using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.PayPal;
using System.Net.Http.Headers;
using System.Text;

namespace OrderFoodOnlineSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class PayPalController : Controller
    {
        private readonly IConfiguration _configuration;

        public PayPalController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ActionResult> Success(string orderId)
        {
            Console.WriteLine($"Order ID: {orderId}");
            var isPaymentVerified = await VerifyPayment(orderId);
            if (isPaymentVerified)
            {
                return RedirectToAction("PlaceOrder", "Order", new { paymentMethod = PaymentMethod.PayPal });
            }
            else
            {
                return View("Failure");
            }
        }

        private async Task<bool> VerifyPayment(string orderId)
        {
            var clientId = _configuration["PayPalOptions:ClientId"];
            var clientSecret = _configuration["PayPalOptions:ClientSecret"];

            ViewBag.ClientId = clientId;

            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

                var url = $"https://api.sandbox.paypal.com/v2/checkout/orders/{orderId}";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var order = JsonConvert.DeserializeObject<PayPalOrder>(content);

                    if (order.status == "COMPLETED")
                    {
                        return true;
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                }
            }
            return false;
        }

        
    }
}