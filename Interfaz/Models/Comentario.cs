namespace Interfaz.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public string Texto { get; set; }
        public int Valoracion { get; set; }
        public DateTime Fecha { get; set; }
        public string Origen { get; set; }  // Campo para especificar la base de datos de origen
    }

}
