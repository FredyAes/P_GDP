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

        // L�gica para autenticar al usuario
        // Comprobar que el usuario existe y la contrase�a es correcta
        bool isAuthenticated = AuthenticateUser(Input.Email, Input.Password);
        if (!isAuthenticated)
        {
            ModelState.AddModelError("", "Usuario o contrase�a incorrectos.");
            return Page();
        }

        // Redirigir a la p�gina de cursos
        return RedirectToPage("Courses");
    }

    private bool AuthenticateUser(string email, string password)
    {
        // Implementar la l�gica de autenticaci�n (verificar en la base de datos)
        return email == "test@example.com" && password == "password123"; // Simulaci�n
    }
}
