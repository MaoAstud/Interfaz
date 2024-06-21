using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Interfaz.Services;
using System.Threading.Tasks;
using Interfaz.Models;

namespace Interfaz.Pages
{
    public class CatalogoModel : PageModel
    {
        private readonly ApiService _apiService;

        public CatalogoModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public string Tienda { get; private set; }
        public List<Producto> Productos { get; private set; }

        public async Task OnGetAsync(string tienda)
        {
            Tienda = tienda;
            // Obtener productos desde el ApiService en lugar de usar datos de ejemplo
            var todosLosProductos = await _apiService.GetAllProductosAsync();

            // Filtrar productos por tienda
            Productos = todosLosProductos.Where(p => p.Tienda == tienda).ToList();
        }

        public IActionResult OnPostAgregarAlCarrito(int id, string nombre, decimal precio, string imagenUrl)
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<ItemCarrito>>("Carrito") ?? new List<ItemCarrito>();

            var item = carrito.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                carrito.Add(new ItemCarrito { Id = id, Nombre = nombre, Precio = precio, Cantidad = 1, ImagenUrl = imagenUrl });
            }
            else
            {
                item.Cantidad++;
            }

            HttpContext.Session.SetObjectAsJson("Carrito", carrito);

            return RedirectToPage("/Carrito");
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



