using Microsoft.AspNetCore.Mvc;
using Serminar_WebApi_MVC.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.Text;

namespace Serminar_WebApi_MVC.Controllers
    
{
    public class StoreController : Controller
    {
        Uri baseAdress = new Uri("http://localhost:5031/api");
        private readonly HttpClient _client;

        public StoreController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress+"/Store/Get").Result;

            if(respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<Product>>(data);
            }

            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8,
                    "application/json");
                HttpResponseMessage respone = _client.PostAsync(_client.BaseAddress +
                    "/Store/Post", content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Product product = new Product();
                HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress +
                    "/Store/Get/" + id).Result;

                if (respone.IsSuccessStatusCode)
                {
                    string data = respone.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Product>(data);
                }
                return View(product);
            }
            catch (Exception ex)
            {
                return View();
            }
            return View() ;
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8,
                    "application/json");
                HttpResponseMessage respone = _client.PutAsync(_client.BaseAddress +
                    "/Store/Put", content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Product product = new Product();
                HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress +
                    "/Store/Get/" + id).Result;

                if (respone.IsSuccessStatusCode)
                {
                    string data = respone.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Product>(data);
                }
                return View(product);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                HttpResponseMessage respone = _client.DeleteAsync(_client.BaseAddress + "/Store/Delete/" + 
                    id).Result;

                if (respone.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
    }
}
