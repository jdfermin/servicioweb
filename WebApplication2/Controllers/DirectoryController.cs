using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Data;
using Directory = WebApplication2.Models.Directory;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public DirectoryController(AppDbContext context)
        {
            dbContext = context;
        }
        
        
        [HttpGet("/status/")]
        public async Task<ActionResult<string>> GetStatus()
        {
            return Ok("pong");
        }
        
        [HttpGet("/directories/")]
        public async Task<ActionResult<DirectoryPage>> GetDirectories(int page)
        {
            if (!dbContext.Directory.Any())
                return NotFound();
            
            var resultadosPagina = 5f;
        
            var directories = dbContext.DirectoryEmail
                .Select(
                    d => new DirectoryDTO()
                    {
                        id = d.directoryID,
                        name = d.directory.name,
                        emails = new List<string>()
                    }
                )
                .Skip((page - 1) * (int) resultadosPagina)
                .Take((int) resultadosPagina)
                .ToList();

            foreach (var dir in directories)
            {
                List<string> emails = dbContext.DirectoryEmail
                    .Where(d => d.directoryID == dir.id)
                    .Select(d => d.email.adress).ToList();
                dir.emails = emails;
            }
        
            string url = "https://localhost:7158/api/directory/?page=";
            
            DirectoryPage pagina = new DirectoryPage()
            {
                count = dbContext.Directory.Count(),
                previous = (page>1) ? url+((int) page-1) : "null",
                next = url+((int) page+1),
                results = directories
            };
            return Ok(pagina);
        }
        
        [HttpPost("/directories")]
        public async Task<ActionResult<DirectoryDTO>> CreateDirectory(CreateDirectoryRequest request)
        {

            Directory directory = new Directory() { name = request.name };
            dbContext.Directory.Add(directory);
            dbContext.SaveChanges();

            directory.id = dbContext.Directory.Where(e => e.name == request.name).Select(e => e.id).FirstOrDefault();

            foreach (var em in request.emails)
            {
                Email email = new Email() { adress = em };
                    dbContext.Email.Add(email);
                    dbContext.SaveChanges();
                    
                int emailID = dbContext.Email.Where(e => e.adress == em).Select(e => e.id).FirstOrDefault();

                dbContext.DirectoryEmail.Add(new DirectoryEmail(){ directoryID = directory.id, emailID = emailID});
            }
            dbContext.SaveChanges();

            return Ok(request);
        }
        
        [HttpGet("/directories/{id}")]
        public async Task<ActionResult<Directory>> GetDirectoryByID(int id)
        {
            if (!dbContext.Directory.Where(d => d.id == id).Any())
                return NotFound();

            Directory directory =
                dbContext.Directory.Where(d => d.id == id).FirstOrDefault();
            
            List<string> emails =
                dbContext.DirectoryEmail
                    .Where(d => d.directoryID == id)
                    .Select(d => d.email.adress).ToList();

            DirectoryDTO directoryDTO = new DirectoryDTO()
            {
                id = directory.id,
                name = directory.name,
                emails = emails
            };

            return Ok(directoryDTO);
        }
        
        [HttpPut("/directories/")]
        public async Task<ActionResult<Directory>> PutDirectory(DirectoryDTO directoryDTO)
        {
            Directory directory = new Directory();
            return Ok(directory);
        }
        
        [HttpPatch("/directories/")]
        public async Task<ActionResult<Directory>> PatchDirectory(DirectoryDTO directoryDTO)
        {
            Directory directory = new Directory();
            return Ok(directory);
        }

        [HttpDelete("/directories/{id}")]
        public async Task<ActionResult> DeleteDirectory(int id)
        {
            Directory directory = dbContext.Directory.Find(id);
            dbContext.Directory.Remove(directory);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
