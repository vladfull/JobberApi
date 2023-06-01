using JobberApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

using MongoDB.Driver;
using Newtonsoft.Json; 

namespace JobberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDataController : ControllerBase
    {
        private readonly ILogger<UsersDataController> _logger;
        private IMongoClient Client { get; set; }
        private IMongoCollection<UserData> ProfCollection { get; set; }
        public UsersDataController(ILogger<UsersDataController> logger)
        {
            _logger = logger;
            Client = new MongoClient("mongodb+srv://vladyslavkukhar99:3Oayyl6gWr4EJY6U@dbforjobbber.gzae2zi.mongodb.net/?retryWrites=true&w=majority");
            var database = Client.GetDatabase("JobberDB");
            ProfCollection = database.GetCollection<UserData>("UsersData");
            
        }
        [HttpPost("PostUserDataAsync")]
        public async Task<IActionResult> PostUserDataAsync(long chatId, string name, string prof, string salary, string location) 
        {
            UserData user = new UserData()
            {
                ChatId = chatId,
                UserName= name,
                UserProffesion = prof,
                UserSalary= salary,
                UserJobLocation=location
            };
            
            await ProfCollection.InsertOneAsync(user);
            return Ok();
        }
        [HttpGet("GetUserDataAsync")]
        public async Task<IActionResult> GetUserDataAsync(long chatId)
        {
            
            return Ok(ProfCollection.FindAsync(filter => filter.ChatId == chatId).Result.ToList()); 
        }
        [HttpDelete("DeleteUserDataAsync")]
        public async Task<IActionResult> DeleteUserDataAsync(long chatId)
        {
            await ProfCollection.DeleteOneAsync(filter => filter.ChatId == chatId);
            return Ok();
        }
        //[HttpPost("PostUserVacanciesAsync")]
        //public async Task<IActionResult> PostUserVacanciesAsync(long chatId, )
        //{
            

        //    await ResumeCollection.InsertOneAsync(userResumeFile);
        //    return Ok();
        //}
    }
}
