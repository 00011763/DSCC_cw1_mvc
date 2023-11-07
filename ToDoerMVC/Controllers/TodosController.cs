using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using ToDoerMVC.Models;

namespace ToDoerMVC.Controllers
{
    public class TodosController : Controller
    {
        // GET
        public ActionResult Index()
        {
            string baseUrl = "http://ec2-54-81-57-229.compute-1.amazonaws.com/api/";
            List<TodoItem> todoItems = new List<TodoItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                HttpResponseMessage response = client.GetAsync("Todos").Result;

                if (response.IsSuccessStatusCode)
                {
                    var todoResponse = response.Content.ReadAsStringAsync().Result;
                    todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(todoResponse);
                }
            }

            return View("Index", todoItems);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Create(TodoItem todoItem)
        {
            string baseUrl = "http://ec2-54-81-57-229.compute-1.amazonaws.com/api/";

            // Use an HttpClient to send a POST request to the API.
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Serialize the todoItem to JSON and send it as the request body.
                var todoItemJson = JsonConvert.SerializeObject(todoItem);
                var content = new StringContent(todoItemJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("Todos", content);
                
            }
            
            return await Task.Run(() => RedirectToAction("Index"));
        }
        
        // GET
        public ActionResult Edit(int id)
        {
            string baseUrl = "http://ec2-54-81-57-229.compute-1.amazonaws.com/api/";
            TodoItem todoItem = new TodoItem();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                HttpResponseMessage response = client.GetAsync($"Todos/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var todoResponse = response.Content.ReadAsStringAsync().Result;
                    todoItem = JsonConvert.DeserializeObject<TodoItem>(todoResponse);
                }
            }

            return View("Edit", todoItem);
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult> Edit(TodoItem todoItem)
        {
            string baseUrl = "http://ec2-54-81-57-229.compute-1.amazonaws.com/api/";

            // Use an HttpClient to send a PUT request to the API.
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Serialize the todoItem to JSON and send it as the request body.
                var todoItemJson = JsonConvert.SerializeObject(todoItem);
                var content = new StringContent(todoItemJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"Todos/{todoItem.Id}", content);
            }
            
            return await Task.Run(() => RedirectToAction("Index"));
        }
        
        // GET
        public ActionResult Delete(int id)
        {
            string baseUrl = "http://ec2-54-81-57-229.compute-1.amazonaws.com/api/";
            TodoItem todoItem = new TodoItem();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                HttpResponseMessage response = client.GetAsync($"Todos/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var todoResponse = response.Content.ReadAsStringAsync().Result;
                    todoItem = JsonConvert.DeserializeObject<TodoItem>(todoResponse);
                }
            }

            return View("Delete", todoItem);
        }
        
        // POST
        [HttpPost]
        public async Task<ActionResult> Delete(TodoItem todoItem)
        {
            string baseUrl = "http://ec2-54-81-57-229.compute-1.amazonaws.com/api/";

            // Use an HttpClient to send a DELETE request to the API.
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"Todos/{todoItem.Id}");
            }
            
            return await Task.Run(() => RedirectToAction("Index"));
        }
        
        // GET
        public ActionResult Details(int id)
        {
            string baseUrl = "http://ec2-54-81-57-229.compute-1.amazonaws.com/api/";
            TodoItem todoItem = new TodoItem();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                HttpResponseMessage response = client.GetAsync($"Todos/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var todoResponse = response.Content.ReadAsStringAsync().Result;
                    todoItem = JsonConvert.DeserializeObject<TodoItem>(todoResponse);
                }
            }

            return View("Details", todoItem);
        }

    }
}