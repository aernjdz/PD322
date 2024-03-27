

namespace Homework_07.Entities
{
   public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
