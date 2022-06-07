namespace Vehicles.Services
{
    public record Vehicle
    {
        public int YearOfConstruction { get; set; }
        public string VehicleId { get; set; }
        public string Model { get; set; }
    }
}
