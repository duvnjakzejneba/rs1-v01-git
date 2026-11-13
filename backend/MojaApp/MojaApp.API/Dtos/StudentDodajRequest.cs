namespace MojaApp.API.Controllers.Dtos
{

    public class StudentDodajRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateOnly DatumRodjenja { get; set; }
        
    }

}
