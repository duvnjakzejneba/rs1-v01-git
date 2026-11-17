using Microsoft.Build.Framework;

namespace MojaApp.API.Controllers.Dtos
{

    public class StudentDodajRequest
    {
        [Required]
        public string Ime { get; set; }
        
        [Required]
        public string Prezime { get; set; }
        
        [Required]
        public string BrojIndeksa { get; set; }
        
        public DateOnly? DatumRodjenja { get; set; }
        
    }

}
