using System.ComponentModel.DataAnnotations;

namespace HarmanCoolProductsService.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(1, 9999999)]
        public int Price { get; set; }
        [MaxLength(50)]
        public string Catagory { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        public bool Instock { get; set; }
        public bool IsDeleted { get; set; }
    }
}
