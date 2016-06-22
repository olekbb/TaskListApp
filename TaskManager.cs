using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskListApp
{
    class TaskManager
    {
        private HttpClient client;
        public string LastCreatedId { get; set; }
        public TaskManager()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("http://windowsphoneuam.azurewebsites.net/api/todotasks/");
            this.client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void UploadTask(ToDoTask task)
        { 
            String taskString = "{\"title\": \"" + task.Title + "\",\"value\": \"" + 
                                task.Value + "\",\"ownerId\": \"" + task.OwnerId + "\"}";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
            request.Content = new StringContent(taskString,
                                                Encoding.UTF8,
                                                "application/json");
            
            client.SendAsync(request)
                  .ContinueWith(responseTask =>
                  {
                      Debug.WriteLine("Response: {0}", responseTask.Result);
                      Regex regex = new Regex(@"(todotasks\/)([0-9]+)");
                      Match match = regex.Match(responseTask.Result.ToString());
                      Debug.WriteLine(match.Success);
                      LastCreatedId = match.Groups[2].ToString();
                      Debug.WriteLine("Id of created task: " + LastCreatedId);
                      task.Id = LastCreatedId;
                  });

        }

        public async Task<List<ToDoTask>> DownloadTasks(string OwnerId)
        {
            var result = await client.GetAsync("http://windowsphoneuam.azurewebsites.net/api/ToDoTasks" + "?OwnerId=" + OwnerId);
            string items = await result.Content.ReadAsStringAsync();
            List<ToDoTask> obj = JsonConvert.DeserializeObject<List<ToDoTask>>(items);
            return obj;
        }

        public void DeleteTask(string id)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent("", Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://windowsphoneuam.azurewebsites.net/api/ToDoTasks" + "?id=" + id)
            };
            httpClient.SendAsync(request);
        }
    }
}
