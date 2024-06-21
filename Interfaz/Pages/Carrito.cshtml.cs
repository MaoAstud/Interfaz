using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using Interfaz.Services;
using System.Threading.Tasks;

namespace Interfaz.Pages
{
    public class CarritoModel : PageModel
    {
        private readonly ApiService _apiService;

        public CarritoModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<ItemCarrito> ItemsCarrito { get; private set; }

        public async Task OnGetAsync()
        {
            ItemsCarrito = HttpContext.Session.GetObjectFromJson<List<ItemCarrito>>("Carrito") ?? new List<ItemCarrito>();

            // Puedes cargar los datos del carrito desde el servidor si es necesario
            // ItemsCarrito = await _apiService.GetAllCarritosAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id, string action)
        {
            ItemsCarrito = HttpContext.Session.GetObjectFromJson<List<ItemCarrito>>("Carrito") ?? new List<ItemCarrito>();
            var item = ItemsCarrito.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                if (action == "increase")
                {
                    item.Cantidad++;
                }
                else if (action == "decrease")
                {
                    item.Cantidad--;
                    if (item.Cantidad <= 0)
                    {
                        ItemsCarrito.Remove(item);
                    }
                }
                else if (action == "remove")
                {
                    ItemsCarrito.Remove(item);
                }

                // Aquí puedes llamar al API para actualizar el carrito en el servidor
                // await _apiService.UpdateCarritoAsync(id, item);

                HttpContext.Session.SetObjectAsJson("Carrito", ItemsCarrito);
            }

            return RedirectToPage();
        }

        public class ItemCarrito
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public string ImagenUrl { get; set; }
        }
    }
}



