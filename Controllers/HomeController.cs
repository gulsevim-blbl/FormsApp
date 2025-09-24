using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;

namespace FormsApp.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {

    }
    public IActionResult Index(string searchString) 
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
        // Filtrelenmiş listeyi view’a gönder
        return View(Products);
    }

    public IActionResult Privacy()
    {
        return View();
    }


}
