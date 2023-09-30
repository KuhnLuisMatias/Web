namespace Web.ViewModels
{
    public class ProductosViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public IFormFile? Imagen_Archivo { get; set; } 
        public int Stock { get; set; }
        public bool Activo { get; set; }
    }
}
