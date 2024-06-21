namespace Interfaz.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Producto> Productos { get; set; }
        public string Origen { get; set; }  // Campo para especificar la base de datos de origen
    }

}
