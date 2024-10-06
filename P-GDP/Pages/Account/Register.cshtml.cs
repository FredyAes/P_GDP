using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class RegisterModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }

    public string CaptchaResponse { get; set; }

    public class InputModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Validar CAPTCHA
        if (!ValidateCaptcha(Request.Form["g-recaptcha-response"]))
        {
            ModelState.AddModelError("", "Por favor, verifica que no eres un robot.");
            return Page();
        }

        // Lógica para registrar el usuario (Guardar en base de datos)
        // Aquí iría la lógica para encriptar la contraseña y guardar los datos de usuario

        return RedirectToPage("Login");
    }

    private bool ValidateCaptcha(string captchaResponse)
    {
        // Aquí implementarías la validación real del CAPTCHA usando Google reCAPTCHA API
        return !string.IsNullOrEmpty(captchaResponse);
    }
}
