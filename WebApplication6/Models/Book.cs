namespace WebApplication6.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

    }
}
