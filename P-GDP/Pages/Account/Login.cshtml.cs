using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class LoginModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Lógica para autenticar al usuario
        // Comprobar que el usuario existe y la contraseña es correcta
        bool isAuthenticated = AuthenticateUser(Input.Email, Input.Password);
        if (!isAuthenticated)
        {
            ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
            return Page();
        }

        // Redirigir a la página de cursos
        return RedirectToPage("Courses");
    }

    private bool AuthenticateUser(string email, string password)
    {
        // Implementar la lógica de autenticación (verificar en la base de datos)
        return email == "test@example.com" && password == "password123"; // Simulación
    }
}
