using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "Ürün Id")] //etiketleme işlemi yapıyoruz. ProductId yerine Ürün Id yazabilirz
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; } = string.Empty; //string? ile aynı anlama geliyor.
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Resim")]
        public string Image { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}