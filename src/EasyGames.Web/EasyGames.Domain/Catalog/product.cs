using System.ComponentModel.DataAnnotations;

namespace EasyGames.Domain.Catalog
{
  
    public class Product
    {
        public int Id { get; set; }  // PK via EF

        [Required, StringLength(120)]
        public string Name { get; set; } = "";

        [Range(0, 999999)]
        public decimal Cost { get; set; }

        [Range(0, 999999)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int OwnerStock { get; set; }

        public decimal Margin() => Price - Cost;
    }
}


