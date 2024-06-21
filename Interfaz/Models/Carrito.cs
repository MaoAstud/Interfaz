namespace Interfaz.Models
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<DetalleCarrito> Detalles { get; set; }
        public string Origen { get; set; }  // Campo para especificar la base de datos de origen
    }

}
