using JobberApi.Models;
using System.Text;
using Newtonsoft.Json;

namespace JobberApi.Clients
{
    public class JobClient
    {
        
        private HttpClient jobclient;
        public JobClient() 
        {
            jobclient = new HttpClient();
        }
        public async Task<JobSearcherModel> GetVacancy(string keywords, string location)
        {
            var content = new StringContent($"{{ \"keywords\": \"{keywords}\", \"location\": \"{location}\" }}", Encoding.UTF8, "application/json");
            var response = await jobclient.PostAsync(Constants.url + Constants.apikey, content);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<JobSearcherModel>(response.Content.ReadAsStringAsync().Result);
            return result;
        }
        //$"{{ \"keywords\": \"{keywords}\", \"location\": \"{location}\" }}"
    }
}
