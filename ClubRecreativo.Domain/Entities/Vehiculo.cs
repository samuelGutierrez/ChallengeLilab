namespace ClubRecreativo.Domain.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int AccesoId { get; set; }
        public Acceso Acceso { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int ValetParkingId { get; set; }
        public ValetParking ValetParking { get; set; }
        public int UbicacionEstacionamientoId { get; set; }
        public UbicacionEstacionamiento UbicacionEstacionamiento { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}
