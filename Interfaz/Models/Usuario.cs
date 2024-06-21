namespace Interfaz.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Origen { get; set; }  // Campo para especificar la base de datos de origen
    }

}
