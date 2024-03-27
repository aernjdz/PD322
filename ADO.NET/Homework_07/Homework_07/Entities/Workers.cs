
namespace Homework_07.Entities
{
   public class Workers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public decimal? Salary { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? PositionId { get; set; }

        public int? ShopId { get; set; }

        public virtual Positions Positions { get; set; }

        public virtual Shops Shops { get; set; }
    }
}
