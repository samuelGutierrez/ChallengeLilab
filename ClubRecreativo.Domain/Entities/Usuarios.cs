namespace ClubRecreativo.Domain.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }
        public Role Rol { get; set; }
    }
}
