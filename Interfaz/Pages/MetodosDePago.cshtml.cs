using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interfaz.Services;
using System.Threading.Tasks;

namespace Interfaz.Pages
{
    public class MetodosDePagoModel : PageModel
    {
        private readonly ApiService _apiService;

        public MetodosDePagoModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string metodo, string nombre, string numeroTarjeta, string fechaExpiracion, string cvv, string numeroCuenta, string banco)
        {
            if (metodo == "tarjeta")
            {
                // L�gica para pago con tarjeta
                var pagoTarjeta = new
                {
                    NombreTitular = nombre,
                    NumeroTarjeta = numeroTarjeta,
                    FechaExpiracion = fechaExpiracion,
                    CVV = cvv
                };

                // Aqu� puedes llamar a una funci�n del ApiService si necesitas
                // await _apiService.SomeFunctionAsync(pagoTarjeta);
            }
            else if (metodo == "transferencia")
            {
                // L�gica para transferencia bancaria
                var pagoTransferencia = new
                {
                    NombreTitular = nombre,
                    NumeroCuenta = numeroCuenta,
                    Banco = banco
                };

                // Aqu� puedes llamar a una funci�n del ApiService si necesitas
                // await _apiService.SomeFunctionAsync(pagoTransferencia);
            }

            // Redirigimos a la p�gina de compra exitosa
            return RedirectToPage("/CompraExitosa");
        }
    }
}



