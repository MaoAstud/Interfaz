using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Interfaz.Pages
{
    public class DetalleProductoModel : PageModel
    {
        public ProductoDetalle Producto { get; private set; }

        public void OnGet(int id, string tienda)
        {
            // Datos de ejemplo
            var productos = new List<ProductoDetalle>
            {
                new ProductoDetalle { Id = 1, Nombre = "Nike Air Max", Precio = 120, Descripcion = "Descripción del Producto 1", Tienda = "Nike", ImagenUrl = "/Imagenes/NikeAirMax.jpg" },
                new ProductoDetalle { Id = 2, Nombre = "Adidas Ultraboost", Precio = 180, Descripcion = "Descripción del Producto 2", Tienda = "Adidas", ImagenUrl = "/Imagenes/Ultraboost.jpg" }
            };

            Producto = productos.FirstOrDefault(p => p.Id == id && p.Tienda == tienda);
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
            public string ImagenUrl { get; set; } // Añadir esta propiedad
        }

        public class ItemCarrito
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public string ImagenUrl { get; set; } // Añadir esta propiedad
        }
    }
}

