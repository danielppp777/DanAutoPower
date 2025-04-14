namespace DanAutoPower.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public virtual ICollection<Model>? Models { get; set; }
    }
}
