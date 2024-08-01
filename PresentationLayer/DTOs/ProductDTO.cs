using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.DTOs
{
    public class ProductDTO
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

    }
}
