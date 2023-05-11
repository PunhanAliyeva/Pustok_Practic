using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Slide
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }



    }
}
