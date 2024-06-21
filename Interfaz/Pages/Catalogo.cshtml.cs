using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Interfaz.Pages
{
    public class CatalogoModel : PageModel
    {
        public string Tienda { get; private set; }
        public List<Producto> Productos { get; private set; }

        public CatalogoModel()
        {
            // Inicializar la lista de productos para evitar NullReferenceException
            Productos = new List<Producto>();
        }

        public void OnGet(string tienda)
        {
            Tienda = tienda;
            // Datos de ejemplo
            var todosLosProductos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Nike Air Max", Precio = 120, Tienda = "Nike", ImagenUrl = "/Imagenes/NikeAirMax.jpg" },
                new Producto { Id = 2, Nombre = "Nike Attack", Precio = 130, Tienda = "Nike", ImagenUrl = "/Imagenes/NikeAttack.png" },
                new Producto { Id = 3, Nombre = "Nike Pegasus 41", Precio = 140, Tienda = "Nike", ImagenUrl = "/Imagenes/NikePegasus41.jpg" },
                new Producto { Id = 4, Nombre = "Nike Dunk Low Premium Next Nature", Precio = 120, Tienda = "Nike", ImagenUrl = "/Imagenes/NikeDunk.png" },
                new Producto { Id = 5, Nombre = "Nike Dunk Low", Precio = 100, Tienda = "Nike", ImagenUrl = "/Imagenes/Dunklow.png" },
                new Producto { Id = 6, Nombre = "Air Jordan 4 Retro \"Oxidized Green\"", Precio = 160, Tienda = "Nike", ImagenUrl = "/Imagenes/AirJordan.png" },
                new Producto { Id = 7, Nombre = "Nike Air Max 1 EasyOn", Precio = 80, Tienda = "Nike", ImagenUrl = "/Imagenes/AirMax1.png" },
                new Producto { Id = 8, Nombre = "Adidas Ultraboost", Precio = 180, Tienda = "Adidas", ImagenUrl = "/Imagenes/Ultraboost.jpg" },
                new Producto { Id = 9, Nombre = "Adidas Gazelle", Precio = 100, Tienda = "Adidas", ImagenUrl = "/Imagenes/Gazelle.jpg" },
                new Producto { Id = 10, Nombre = "Run 70's", Precio = 70, Tienda = "Adidas", ImagenUrl = "/Imagenes/Run.jpg" },
                new Producto { Id = 11, Nombre = "Ultraboost 5.0 Alphaskin", Precio = 80, Tienda = "Adidas", ImagenUrl = "/Imagenes/rosa.jpg" },
                new Producto { Id = 12, Nombre = "Adidas Samba", Precio = 130, Tienda = "Adidas", ImagenUrl = "/Imagenes/Samba.jpg" },
                new Producto { Id = 13, Nombre = "Racer TR23 Shoes Kids", Precio = 80, Tienda = "Adidas", ImagenUrl = "/Imagenes/Racer.jpg" },
                new Producto { Id = 14, Nombre = "Mao Con N Classic", Precio = 50, Tienda = "MaoConN", ImagenUrl = "/Imagenes/clasicos.jpg" },
                new Producto { Id = 15, Nombre = "Mao Con N Runner", Precio = 70, Tienda = "MaoConN", ImagenUrl = "/Imagenes/runner.jpg" },
                new Producto { Id = 16, Nombre = "Mao Con N Boots Beige", Precio = 160, Tienda = "MaoConN", ImagenUrl = "/Imagenes/boots.jpg" },
                new Producto { Id = 17, Nombre = "SM Heels Platinum", Precio = 60, Tienda = "MaoConN", ImagenUrl = "/Imagenes/heels.jpg" },
                new Producto { Id = 18, Nombre = "Teddy OX", Precio = 50, Tienda = "MaoConN", ImagenUrl = "/Imagenes/Teddy.jpg" },
                new Producto { Id = 19, Nombre = "Oxford Lisos", Precio = 120, Tienda = "MaoConN", ImagenUrl = "/Imagenes/botines.jpg" }
            };

            // Filtrar productos por tienda
            Productos = todosLosProductos.FindAll(p => p.Tienda == tienda);
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

        public class Producto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public string Tienda { get; set; }
            public string ImagenUrl { get; set; }
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

