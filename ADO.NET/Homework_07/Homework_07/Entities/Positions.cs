

namespace Homework_07.Entities
{
    public class Positions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Workers> Workers { get; set; }
    }
}
