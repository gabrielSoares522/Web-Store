using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

using System.Diagnostics;
using System.Net.Http.Headers;
using Web_store.Web.Models;
using static System.Net.WebRequestMethods;

namespace Web_store.Web.Controllers
{
    public class BuyerController : Controller
    {
        private readonly ILogger<BuyerController> _logger;
        private string domainAPI;

        public BuyerController(ILogger<BuyerController> logger,IConfiguration configuration)
        {
            domainAPI = configuration.GetSection("WebStoreAPI").Get<string>();

            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            HttpClient client = new HttpClient();
            Uri UrlReq = new Uri(domainAPI+"/api/Products");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            var result = client.GetAsync(UrlReq).GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            products = JsonConvert.DeserializeObject<List<ProductViewModel>>(resultContent);

            if (result.IsSuccessStatusCode) {
                return View(products);
            }
            else {
                return View();
            }
        }
        
        public IActionResult ProductDetails(int Id)
        {
            ProductViewModel product = new ProductViewModel();
            product.Id = Id;
            product.Name = "PLACA DE VÍDEO SAPPHIRE PULSE AMD RADEON RX 7900 XT";
            product.Description = "\r\nCoprocessador gráfico\tAMD RADEON RX 7900\r\nMarca\tSapphire\r\nTamanho da memória RAM da placa gráfica\t20\r\nVelocidade do clock da GPU\t2075 MHz\r\nInterface de saída de vídeo\tDisplayPort, HDMI";
            product.Quantity = 50;
            product.Value = 5379.99;

            return View(product);
        }

        [HttpPost]
        public IActionResult AddCart(string returntUrl)
        {
            return RedirectToAction("Index", new { returntUrl });
        }
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult Payment(PaymentViewModel paymentViewModel)
        {
            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
