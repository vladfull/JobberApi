using JobberApi.Controllers;
using LovePdf.Core;
using LovePdf.Model.Task;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using JobberApi.Clients;
using Microsoft.AspNetCore.Components.Forms;

namespace JobberApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly ILogger<ResumeController> _logger;
        private OpenAIAPI ai;
        
        public ResumeController(ILogger<ResumeController> logger)
        {
            ai = new OpenAIAPI(Constants.ChatGPTkey);
            
            _logger = logger;
        }
        [HttpGet("GetResumeAsync")]
        public async Task<MemoryStream> Get(string question) 
        {

            CompletionRequest request = new CompletionRequest();
            request.Prompt = question;
            request.Model = OpenAI_API.Models.Model.DavinciText;
            request.MaxTokens = 2048;
            string answear = ai.Completions.CreateCompletionAsync(request).Result.ToString();
            var memorystream = new MemoryStream();
            iTextSharp.text.Document resume = new iTextSharp.text.Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(resume, memorystream);
            pdfWriter.CloseStream = false;
            resume.Open();
            Paragraph paragraph = new Paragraph(answear);
            resume.Add(paragraph);
            resume.Close();
            pdfWriter.Close();
            memorystream.Seek(0, SeekOrigin.Begin);
            return memorystream;
            


        }
    }
}
