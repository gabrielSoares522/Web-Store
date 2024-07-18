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

            HttpClient client = new HttpClient();
            Uri UrlReq = new Uri(domainAPI + "/api/Products/" + Id);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            var result = client.GetAsync(UrlReq).GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();


            product = JsonConvert.DeserializeObject<ProductViewModel>(resultContent);

            List<ProductImageViewModel> productImages = new List<ProductImageViewModel>();

			HttpClient clientImages = new HttpClient();
			Uri UrlReqImages = new Uri(domainAPI + "/api/ProductImages?idProduct=" + Id);

			clientImages.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            result = clientImages.GetAsync(UrlReqImages).GetAwaiter().GetResult();
            resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var productDetail = new ProductDetailsViewModel();

			productDetail.Id = product.Id;
			productDetail.Name = product.Name;
			productDetail.Description = product.Description;
			productDetail.Quantity = product.Quantity;
			productDetail.Value = product.Value;

			productDetail.Images = JsonConvert.DeserializeObject<List<ProductImageViewModel>>(resultContent);

            return View(productDetail);
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
