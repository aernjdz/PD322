
namespace Homework_07.Entities
{
   public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
