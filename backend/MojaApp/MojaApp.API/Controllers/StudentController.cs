using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MojaApp.API.Controllers.Data;
using MojaApp.API.Controllers.Dtos;
using MojaApp.API.Controllers.Models;

namespace MojaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(AppDbContext db) : ControllerBase
    {

        private static StudentResponse Mapiraj(Student s)
        {
            return new StudentResponse()
            {
                Id = s.Id,
                ImePrezime = $"{s.Ime} {s.Prezime}", 
                BrojIndeksa = s.BrojIndeksa, 
                DatumRodjenja = s.DatumRodjenja
            };
        }
        
        [HttpGet]
        public async Task<List<StudentResponse>> GetAll(CancellationToken ct)
        {
            List<Student> students = await db.Studenti.ToListAsync(ct); 
            return students.Select(Mapiraj).ToList();
        }
        
        [HttpGet("{id}")]
        public StudentResponse GetById(int id)
        {
            var s = StudentStorage._students.Where(x=>x.Id == id).Select(Mapiraj).FirstOrDefault();
            
            if (s == null)
                throw new Exception("nema studenta");
            
            return s;
        }

        [HttpPost]
        public int Dodaj([FromBody]StudentDodajRequest request)
        {
            
            var maxID = StudentStorage._students.Max(x => x.Id);
            var s = new Student
            {
                Id = maxID + 1,
                Ime = request.Ime,
                Prezime = request.Prezime,
                DatumRodjenja = request.DatumRodjenja
            };
                
            StudentStorage._students.Add(s);
            return s.Id;
        }

        [HttpDelete]
        public IActionResult Obrisi(int studentId)
        {
            var s = StudentStorage._students.FirstOrDefault(x=>x.Id == studentId);
            if (s == null)
                return BadRequest(); 
            
            StudentStorage._students.Remove(s);
            return Ok();
        }
    }
}
