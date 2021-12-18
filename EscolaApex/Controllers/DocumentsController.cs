using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EscolaApex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public void Upload()
        {
            var file = Request.Form.Files[0];
            string cpf = Request.Form["cpf"];
            var folderName = Path.Combine("Resources","Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                fileName = cpf +"."+fileName.Split(".")[1];
                var fullPath = Path.Combine(pathToSave,fileName);                
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
        }
        [HttpGet]
        public IActionResult ReturnFile([FromQuery]string nameFile) 
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSearch = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            IEnumerable<string> files = Directory.GetFiles(pathToSearch).Where(x => x.Contains(nameFile));          
            byte[] image = System.IO.File.ReadAllBytes(files.First());
            return File(image,"image/jpeg",files.First().Split("Images\\")[1],false);
        }
    }
}
