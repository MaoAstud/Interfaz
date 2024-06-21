using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interfaz.Pages
{
    public class MetodosDePagoModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string metodo, string nombre, string numeroTarjeta, string fechaExpiracion, string cvv, string numeroCuenta, string banco)
        {
            // Aquí puedes manejar la lógica del método de pago seleccionado
            if (metodo == "tarjeta")
            {
                // Lógica para pago con tarjeta
                // nombre, numeroTarjeta, fechaExpiracion, cvv
            }
            else if (metodo == "transferencia")
            {
                // Lógica para transferencia bancaria
                // nombre, numeroCuenta, banco
            }

            // Redirigimos a la página de compra exitosa
            return RedirectToPage("/CompraExitosa");
        }
    }
}


