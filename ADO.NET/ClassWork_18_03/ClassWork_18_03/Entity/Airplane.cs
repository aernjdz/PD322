namespace ClassWork_18_03.Entity
{
    public class Airplane
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int MaxPassanger { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
