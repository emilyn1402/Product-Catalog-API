using System.ComponentModel.DataAnnotations;

namespace ProductCatalogAPI.DTOs
{
    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 1000000)]
        public decimal Price { get; set; }

        [Range(0, 1000)]
        public int Stock {  get; set; }
    }
}
