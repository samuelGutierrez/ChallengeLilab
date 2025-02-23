namespace ClubRecreativo.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
