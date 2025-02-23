namespace ClubRecreativo.Domain.Entities
{
    public class Acceso
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
