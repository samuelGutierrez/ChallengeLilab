namespace ClubRecreativo.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string TipoCliente { get; set; } // Visitante o Miembro
        public ICollection<Acceso> Accesos { get; set; }
    }
}
