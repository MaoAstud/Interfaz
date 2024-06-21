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
    public class DetalleProductoModel : PageModel
    {
        private readonly ApiService _apiService;

        public DetalleProductoModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public ProductoDetalle Producto { get; private set; }

        public async Task OnGetAsync(int id, string tienda)
        {
            // Obtener el producto desde el ApiService
            var productos = await _apiService.GetAllProductosAsync();

            Producto = productos
                .Where(p => p.Tienda == tienda)
                .Select(p => new ProductoDetalle
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Descripcion = p.Descripcion,
                    Tienda = p.Tienda,
                    ImagenUrl = p.ImagenUrl
                })
                .FirstOrDefault(p => p.Id == id);
        }

        public IActionResult OnPost(int id, string nombre, decimal precio, string descripcion, string tienda, int cantidad, string imagenUrl)
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<ItemCarrito>>("Carrito") ?? new List<ItemCarrito>();

            var item = carrito.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                carrito.Add(new ItemCarrito { Id = id, Nombre = nombre, Precio = precio, Cantidad = cantidad, ImagenUrl = imagenUrl });
            }
            else
            {
                item.Cantidad += cantidad;
            }

            HttpContext.Session.SetObjectAsJson("Carrito", carrito);

            return RedirectToPage("/Carrito");
        }

        public class ProductoDetalle
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public string Descripcion { get; set; }
            public string Tienda { get; set; }
            public string ImagenUrl { get; set; }
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


