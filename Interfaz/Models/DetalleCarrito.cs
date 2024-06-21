namespace Interfaz.Models
{
    public class DetalleCarrito
    {
        public int DetalleCarritoId { get; set; }
        public int CarritoId { get; set; }
        public Carrito Carrito { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Origen { get; set; }  // Campo para especificar la base de datos de origen
    }

}
