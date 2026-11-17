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
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentResponse>>? GetById(int id, CancellationToken ct)
        {
            Student? student = await db.Studenti.FirstOrDefaultAsync(c => c.Id == id, ct);

            if (student == null)
                return NotFound();

            return Ok(Mapiraj(student)); 
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> Dodaj(StudentDodajRequest request, CancellationToken ct)
        {
            
            Student student = new Student
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                DatumRodjenja = request.DatumRodjenja,
                DatumKreiranja = DateTime.Now,
            };

            db.Studenti.Add(student);
            await db.SaveChangesAsync(ct);
                
            return Ok(Mapiraj(student));
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
