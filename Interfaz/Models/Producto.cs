namespace Interfaz.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; } // Asegúrate de incluir esta propiedad
        public string Tienda { get; set; } // Asegúrate de incluir esta propiedad
        public string ImagenUrl { get; set; } // Asegúrate de incluir esta propiedad
    }
}

