using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interfaz.Services;
using System.Threading.Tasks;
using Interfaz.Models;

namespace Interfaz.Pages
{
    public class CalificarCompraModel : PageModel
    {
        private readonly ApiService _apiService;

        public CalificarCompraModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public string Comentario { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Rating < 1 || Rating > 5)
            {
                ModelState.AddModelError(string.Empty, "Por favor, seleccione un grado de satisfacción válido.");
                return Page();
            }

            var nuevaCalificacion = new Comentario
            {
                Valoracion = Rating, // Usar la propiedad Valoracion
                Texto = Comentario,
                UsuarioId = 1, // Puedes ajustar esto según sea necesario
                Fecha = DateTime.Now
            };

            await _apiService.CreateComentarioAsync(nuevaCalificacion);

            return RedirectToPage("/CalificacionExitosa");
        }
    }
}




