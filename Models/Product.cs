using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    //2.yol [Bind("Name,Price")] burada da bind edilmesini istediğimiz propertyleri belirtebiliriz.
    public class Product
    {
        [Display(Name = "Ürün Id")] //etiketleme işlemi yapıyoruz. ProductId yerine Ürün Id yazabilirz
                                    //3.yol olarak da bind edilmesini istemedğimiz propertylerin üzerine [BindNever] attribute unu ekleyebiliriz.
                                    //[BindNever] şeklinde kullanılır.
        public int ProductId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Ürün adı en az 3 en fazla 100 karakter olmalıdır.")] //en az 3 en fazla 100 karakter olabilir
        [Display(Name = "Ürün Adı")]
        public string? Name { get; set; }
        // public string Name { get; set; } = string.Empty; //string? ile aynı anlama geliyor.
        [Display(Name = "Fiyat")]
        [Required, Range(1, 100000, ErrorMessage = "Fiyat 1 ile 10000 arasında olmalıdır.")] //fiyat 1 ile 10000 arasında olmalı
        public decimal? Price { get; set; }
        [Display(Name = "Resim")]
        [Required]
        public string? Image { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        [Display(Name = "Category")]

        [Required]
        public int? CategoryId { get; set; }
    }
}