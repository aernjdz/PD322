

namespace Homework_07.Entities
{
    public class Shops
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public int? ParkingAreaId { get; set; }

        public virtual Cities City { get; set; }
        public virtual Products ParkingArea { get; set; }

        public virtual ICollection<Workers> Workers { get; set; }

    }
}
