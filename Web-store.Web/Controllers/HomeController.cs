using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Web;
using Web_store.Web.Models;

namespace Web_store.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string domainAPI;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            domainAPI = configuration.GetSection("WebStoreAPI").Get<string>();

            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel == null) {
                return RedirectToAction("login");
            }

            var passwordEncrypted = CreateMD5(loginViewModel.Password);
            //var encodedLogin = HttpUtility.UrlEncode(loginViewModel.Email);

            HttpClient client = new HttpClient();

            Uri UrlReq = new Uri(domainAPI + "/api/Users/validateLogin");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string bodyContent = "{ \"Login\": \""+loginViewModel.Email+"\", \"Password\": \""+passwordEncrypted+"\" }";
            var content = new StringContent(bodyContent, Encoding.UTF8, "application/json");

            var result = client.PostAsync(UrlReq, content).GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            

            if (result.IsSuccessStatusCode) {
                if (resultContent != "") {
                    var user = JsonConvert.DeserializeObject<UserViewModel>(resultContent);
                    
                    if (user.AccountTypeId == 2) {
                        return RedirectToAction("index", "Seller");
                    }
                    else {
                        return RedirectToAction("index", "Buyer");
                    }
                }else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        public IActionResult SignUp()
        {
            return View();
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            HttpClient client = new HttpClient();
            Uri UrlReq = new Uri(domainAPI + "/api/Users");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            string passwordEncrypted = CreateMD5(signUpViewModel.Password);

            string bodyContent = "{ \"FirstName\": \"" + signUpViewModel.FirstName + "\", " +
                "\"LastName\": \"" + signUpViewModel.LastName + "\"," +
                "\"NickName\": \"" + signUpViewModel.NickName + "\"," +
                "\"Email\": \"" + signUpViewModel.Email + "\"," +
                "\"Password\": \"" + passwordEncrypted + "\", " +
                "\"DateBirth\": \"" + signUpViewModel.DateBirth.ToString("yyyy-MM-ddTHH:mm:ss") + "\"," +
                "\"Document\": \"" + signUpViewModel.Document + "\"," +
                "\"AccountTypeId\": 1 }";

            var content = new StringContent(bodyContent,
                Encoding.UTF8,
                "application/json");

            var result = client.PostAsync(UrlReq, content).GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode) {
                return RedirectToAction("index");
            }
            else {
                return RedirectToAction("signUp");
            }
        }
    }
}
