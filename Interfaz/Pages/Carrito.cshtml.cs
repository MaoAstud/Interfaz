using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;

namespace Interfaz.Pages
{
    public class CarritoModel : PageModel
    {
        public List<ItemCarrito> ItemsCarrito { get; private set; }

        public void OnGet()
        {
            ItemsCarrito = HttpContext.Session.GetObjectFromJson<List<ItemCarrito>>("Carrito") ?? new List<ItemCarrito>();
        }

        public IActionResult OnPost(int id, string action)
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


