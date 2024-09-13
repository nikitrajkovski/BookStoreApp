using AdminApplication.Models;
using Domain.Identity;
using ExcelDataReader;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace EShopAdminApplication.Controllers
{
    public class UserController : Controller
    {
        //public UserManager<EShopApplicationUser> usermanager;
        //public UserController(UserManager<EShopApplicationUser> usermanager)
        //{
        //    this.usermanager = usermanager;
        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ImportUsers(IFormFile file)
        {
            string directoryPath = $"{Directory.GetCurrentDirectory()}\\files";

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string pathToUpload = $"{directoryPath}\\{file.FileName}";
            using (var stream = new FileStream(pathToUpload, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            List<BookAppUser> users = getAllUsersFromFile(file.FileName);
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5121/API/Admin/ImportAllUsers";
            HttpContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8,
            "application/json");
            HttpResponseMessage response = client.PostAsync(URL, content).Result;
            var data = response.Content.ReadAsAsync<bool>().Result;
            return RedirectToAction("Index", "Order");
        }
        private List<BookAppUser> getAllUsersFromFile(string fileName)
        {
            List<BookAppUser> users = new List<BookAppUser>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new BookAppUser
                        {
                            FirstName = reader.GetValue(0).ToString(),
                            LastName = reader.GetValue(1).ToString(),
                            Address = reader.GetValue(2).ToString(),
                            Email = reader.GetValue(3).ToString(),
                            Password = reader.GetValue(4).ToString(),
                            ConfirmPassword = reader.GetValue(5).ToString()
                        });
                    }

                }
            }

            return users;

        }


    }
}