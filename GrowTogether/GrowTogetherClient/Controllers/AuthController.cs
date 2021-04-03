using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GrowTogetherClient.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;

namespace GrowTogetherClient.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment = null;
        public AuthController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        private static readonly HttpClient client = new HttpClient();


        // GET: LoginController/Create
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult UploadFiles()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> UploadFiles(Material material)
        {
            Material file = new Material();
            Material send = new Material();
            string uniqueFileName1 = null;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            uniqueFileName1 = Guid.NewGuid().ToString() + "_" + material.Name;
            string filepath = Path.Combine(uploadsFolder, uniqueFileName1);
            Console.WriteLine(file.file);
            material.file.CopyTo(new FileStream(filepath, FileMode.Create));

            // HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44373/FileUpload/upload");

            send.Name = material.Name;
            send.Path = filepath;
            var myContent = JsonConvert.SerializeObject(send);
            var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:44373/FileUpload/upload", stringContent);
            string result = response.Content.ReadAsStringAsync().Result;
            var files = JsonConvert.DeserializeObject<Material>(result);
            //return Json(user);
            if (files != null)
            {
                return RedirectToAction("GetFiles");
            }
            else
            {
                return View();
            }
           
        }
        // POST: LoginController/Create
        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(IFormCollection collection)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44302/api/account/login");
            User register = new User();
            register.UserName = collection["UserName"];
            register.Password = collection["Password"];
          

            var myContent = JsonConvert.SerializeObject(register);
            var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:44373/Authentication/Login", stringContent);
            string result = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            //return Json(user);
            if (user != null)
            {
                HttpContext.Session.SetString("Token", user.Token.ToString());
                return RedirectToAction("UploadFiles");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(IFormCollection collection)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44302/api/account/login");
            User register = new User();
            register.UserName = collection["UserName"];
            register.Password = collection["Password"];
            register.FirstName = collection["FirstName"];
            register.LastName = collection["LastName"];
   
            var myContent = JsonConvert.SerializeObject(register);
            var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:44373/Authentication/Register", stringContent);
            string result = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            //return Json(user);
            if (user != null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:44373/FileUpload/Materials");

            string result = response.Content.ReadAsStringAsync().Result;
            //return Json(result);
            var files = JsonConvert.DeserializeObject<IEnumerable<Material>>(result);
            
            return View(files);

        }
        

      
    }
}
