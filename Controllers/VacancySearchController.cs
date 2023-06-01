using JobberApi.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;


namespace JobberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancySearchController : ControllerBase
    {
        
        private readonly ILogger<VacancySearchController> _logger;
        public VacancySearchController(ILogger<VacancySearchController> logger)
        {
            _logger = logger;
            
        }
        [HttpPost(Name = "VacancySearch")]
        public IActionResult Post(string keywords, string location) 
        {
            JobClient client = new JobClient();
            return Ok(client.GetVacancy(keywords, location).Result);
        }
    }
}
