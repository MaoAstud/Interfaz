using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interfaz.Pages
{
    public class CalificarCompraModel : PageModel
    {
        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public string Comentario { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Rating < 1 || Rating > 5)
            {
                ModelState.AddModelError(string.Empty, "Por favor, seleccione un grado de satisfacci�n v�lido.");
                return Page();
            }

            // Aqu� puedes manejar la l�gica para guardar la calificaci�n y el comentario
            // Por ejemplo, guardarlo en una base de datos o enviar un correo electr�nico

            return RedirectToPage("/CalificacionExitosa");
        }
    }
}


