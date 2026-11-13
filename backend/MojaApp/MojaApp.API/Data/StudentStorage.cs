using MojaApp.API.Controllers.Models;

namespace MojaApp.API.Controllers.Data;

public class StudentStorage
{
    public static List<Models.Student> _students = new List<Student>(); 
    
    public static List<Student> GetAll()
    {
        return _students;
    }
}

