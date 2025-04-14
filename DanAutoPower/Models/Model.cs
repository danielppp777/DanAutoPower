namespace DanAutoPower.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public virtual Brand? Brand { get; set; }
        public string Name { get; set; }
    }
}
