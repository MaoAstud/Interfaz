using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Interfaz.Services;
using Interfaz.Models;

namespace Interfaz.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApiService _apiService;

        public LoginModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Llama al servicio API para autenticar al usuario
            var usuario = await _apiService.AuthenticateUserAsync(Username, Password);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre) // Usa la propiedad correcta para el nombre del usuario
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "Nombre de usuario o contraseña incorrectos.";
                return Page();
            }
        }
    }
}





