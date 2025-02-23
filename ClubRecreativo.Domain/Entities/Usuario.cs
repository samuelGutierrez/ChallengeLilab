namespace ClubRecreativo.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }
        public Role Rol { get; set; }
    }
}
