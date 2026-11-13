namespace MojaApp.API.Controllers.Models;

public class Student
{
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string BrojIndeksa { get; set; }

    public int? OpstinaRodjenjaId { get; set; }
    public Opstina OpstinaRodjenja { get; set; }
    public DateOnly? DatumRodjenja { get; set; }
    public DateTime DatumKreiranja { get; set; }
    public string? SlikaStudenta { get; set; }
}