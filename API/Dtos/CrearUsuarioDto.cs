namespace API.Dtos
{
    public class CrearUsuarioDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Id_Rol { get; set; }
        public bool Activo { get; set; }
        public string Clave { get; set; }
    }
}
