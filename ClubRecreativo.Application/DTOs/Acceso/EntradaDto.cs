namespace ClubRecreativo.Application.DTOs.Acceso
{
    public class EntradaDto
    {
        public string NombreCliente { get; set; }
        public DateTime FechaEntrada { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int ValetParkingId { get; set; }
        public int UbicacionEstacionamientoId { get; set; }
    }
}
