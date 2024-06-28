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
        // GET: HomeController
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
            //verificar se o login e valido
            if (loginViewModel == null)
            {
                return RedirectToAction("login");
            }

            
            var passwordEncrypted = CreateMD5(loginViewModel.Password);
            var encodedLogin = HttpUtility.UrlEncode(loginViewModel.Email);
            HttpClient client = new HttpClient();

            Uri UrlReq = new Uri(domainAPI + "/api/User/"+ encodedLogin+"/"+ passwordEncrypted);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            var result = client.GetAsync(UrlReq).GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            

            if (result.IsSuccessStatusCode)
            {
                if (resultContent != "")
                {
                    var user = JsonConvert.DeserializeObject<UserViewModel>(resultContent);
                    if (user.AccountTypeId == 2)
                    {
                        return RedirectToAction("index", "Seller");
                    }
                    else
                    {
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
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
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
            //    FirstName { get; set; }
            //public string LastName { get; set; }
            //public string NickName { get; set; }
            //public string Email { get; set; }
            //public string Password { get; set; }
            //public DateTime DateBirth { get; set; }
            //public string Document { get; set; }
            //public int AccountTypeId { get; set; }
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
            if (result.IsSuccessStatusCode)
            { 

            return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("signUp");
            }
        }
    }
}
