using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_store.Web.Models;

namespace Web_store.Web.Controllers
{
    public class SellerController : Controller
    {
        private readonly ILogger<SellerController> _logger;

        public SellerController(ILogger<SellerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditStore()
        {
            return View();
        }

        public IActionResult RegisterProduct()
        {
            return View();
        }

        public IActionResult EditProduct()
        {
            return View();
        }

        public IActionResult RegisterBatch()
        {
            return View();
        }

        public IActionResult EditBatch()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
