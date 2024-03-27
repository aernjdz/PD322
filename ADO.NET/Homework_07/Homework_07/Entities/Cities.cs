
namespace Homework_07.Entities
{
    public class Cities
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public virtual Countries Countries { get; set; }

        public virtual ICollection<Shops> Shops { get; set; }
    }
}
