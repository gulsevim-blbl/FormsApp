using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {

    }
    [HttpGet]
    public IActionResult Index(string searchString, string category)
    {
        //flitreleme için linq kullanıldı artık url den gelen searchString e göre filtreleme yapılacak

        // Repository’den ürünleri al
        var Products = Repository.Products;
        // Eğer searchString boş değilse filtre uygula
        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString; // Arama kutusunu doldurmak için
            Products = Products.Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
        }



        if (!String.IsNullOrEmpty(category) && category != "0") //tüm kategoriler seçilirse filtreleme yapma
        {

            Products = Products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }



        // ViewBag.Cateegories = new SelectList(Repository.Categories,"CategoryId","Name",category);
        //categorileri sayfaya gönder
        //4.parametre seçili olanı belirtir

        // ViewModel oluştur ve verileri atarız. 

        var model = new ProductViewModel
        {
            Products = Products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        // Filtrelenmiş listeyi view’a gönder
        return View(model);
    }    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name"); 
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product model)
    //public IActionResult Create([Bind["Name,"Price"] Product model) böyle yaparsak sadece name ve price ı alır diğerlerini almaz 1.yol
    {
        //Hataları Yazdırmak için
        if (ModelState.IsValid)
        {
            model.ProductId = Repository.Products.Count + 1;
            Repository.CreateProduct(model); //Repository deki CreateProduct methodunu çağırdık formdan gelen bilgileri eklemek için
                                             // return View(); 
                                             //tekrar create sayfasına yönlendirir Form tekrar kullanıcının karşısına gelir bunu kapatırız
            return RedirectToAction("Index"); //farklı bir methodun çalışmasını sağlar. ındex methoduna yönlendirir burada.
        }
        ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name"); 
        return View(model); //hata varsa tekrar formu doldurması için modeli geri gönderiyoruz

    }

}
