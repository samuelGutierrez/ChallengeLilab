namespace ClubRecreativo.Domain.Entities
{
    public class UbicacionEstacionamiento
    {
        public int Id { get; set; }
        public string CodigoUbicacion { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
