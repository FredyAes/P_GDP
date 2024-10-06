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

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Las contrase�as no coinciden.")]
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

        // L�gica para registrar el usuario (Guardar en base de datos)
        // Aqu� ir�a la l�gica para encriptar la contrase�a y guardar los datos de usuario

        return RedirectToPage("Login");
    }

    private bool ValidateCaptcha(string captchaResponse)
    {
        // Aqu� implementar�as la validaci�n real del CAPTCHA usando Google reCAPTCHA API
        return !string.IsNullOrEmpty(captchaResponse);
    }
}
