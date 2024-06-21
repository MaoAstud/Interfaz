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
            // Aqu� puedes manejar la l�gica del m�todo de pago seleccionado
            if (metodo == "tarjeta")
            {
                // L�gica para pago con tarjeta
                // nombre, numeroTarjeta, fechaExpiracion, cvv
            }
            else if (metodo == "transferencia")
            {
                // L�gica para transferencia bancaria
                // nombre, numeroCuenta, banco
            }

            // Redirigimos a la p�gina de compra exitosa
            return RedirectToPage("/CompraExitosa");
        }
    }
}


