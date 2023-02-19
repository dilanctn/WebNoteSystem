using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebNoteSystem.Controllers
{
    public class NotesTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44392/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        //ekleme 
        [HttpGet]
        public IActionResult AddNotes()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNotes(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonNotes = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonNotes, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44392/api/Default",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        //güncelleme 
        [HttpGet]
        public async Task<IActionResult> UpdateNotes(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage=await httpClient.GetAsync("https://localhost:44392/api/Default/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonNotes = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonNotes);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotes(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonNotes = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonNotes, Encoding.UTF8, "application/json");
            var responseMessage=await httpClient.PutAsync("https://localhost:44392/api/Default/" ,content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        //silme işlemi
        public async Task<IActionResult> DeleteNotes(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44392/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    public class Class1
    {
        public int ID { get; set; }
        public string Tıtle { get; set; }
        public string Content { get; set; }
    }
}
