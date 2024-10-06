using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class CoursesModel : PageModel
{
    public List<Course> Courses { get; set; }

    public void OnGet()
    {
        // Obtener los cursos de la base de datos
        Courses = new List<Course>
        {
            new Course { Id = 1, Title = "Curso de C#", Description = "Aprende C# desde cero.", Image = "curso_csharp.jpg" },
            new Course { Id = 2, Title = "Curso de Python", Description = "Aprende Python avanzado.", Image = "curso_python.jpg" },
        };
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
