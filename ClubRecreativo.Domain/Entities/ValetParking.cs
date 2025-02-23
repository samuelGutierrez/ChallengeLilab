﻿namespace ClubRecreativo.Domain.Entities
{
    public class ValetParking
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
