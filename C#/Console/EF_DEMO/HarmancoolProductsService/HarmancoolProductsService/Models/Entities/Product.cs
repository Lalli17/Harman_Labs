using System.ComponentModel.DataAnnotations;

namespace HarmancoolProductsService.Models.Entities
{
    public class Product
    {
        //not related to api
        public int Id { get; set; }
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(1,9999999)]
        public int Price { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        public bool InStock { get; set; }
        public bool IsDeleted { get; set; }

    }
}
