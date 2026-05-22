namespace VideotecaAPI.Models
{
    public class Pelicula
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AnioLanzamiento { get; set; }
        public string Idioma { get; set; }
        public int DuracionMin { get; set; }
        public int IdCategoria { get; set; }
        public Categoria categoria { get; set; }
    }
}
