using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        //Context & CONSTRUCTOR & FoddRepository SUBJECT TANIMLAMA
        private readonly Context _context;
        FoodRepository repository;
        public FoodController(Context context)
        {
            _context = context;
            repository = new FoodRepository(_context);
        }

        //***********************************************************

        //Food Home Page & Pagination
        /*
          ToPagesList() 2 parametre alır ;
         1-) Sayfa kaçtan başlayacak
         2-) Sayfa kaç adet değer olacak
         Yani sayfalama işlemi 1. sayfadan başlasın  
         Her sayfada 3 tane veri olsun
        */

        /*
         Sayfalar arası geçiş yapabilmek için ;
        int page =1 (İlk değeri 1 olan parametre gönderdim
        ve bunu ToPageList içerisine yolladım)
        
        Bunu @htmlhelper ile Index.cshtml sayfasında kullandım
         */

        public IActionResult Index(int page = 1)
        {
            return View(repository.TList("Category").ToPagedList(page,3));
        }

        //***********************************************************

        //A New Food Page [GET]
        [HttpGet]
        public IActionResult FoodAdd()
        {
            ViewBag.newFood = _context.Categories.ToList();
            return View();
        }

        //A New Food Page [POST]
        [HttpPost]
        public IActionResult FoodAdd(Food p)
        {
            repository.TAdd(p);
            return RedirectToAction("Index");
        }

        //***********************************************************

        //Food Delete Page
        public IActionResult FoodRemove(int id)
        {
            repository.TDelete(new Food {FoodID=id });
            return RedirectToAction("Index");
        }

        //***********************************************************

        //Food List Page & Use To Dropdownlist 
        public IActionResult FoodGet(int id)
        {
            ViewBag.newFood2 = _context.Categories.ToList();

            var x = repository.TGet(id);
            Food fd = new Food()
            {
                FoodID = x.FoodID,
                Name = x.Name,
                Stock = x.Stock,
                Price = x.Price,
                ImageURL = x.ImageURL,
                CategoryID = x.CategoryID,
                Description = x.Description
            };
            return View(fd);
        }

        //***********************************************************

        //Food Update Page [POST]
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = repository.TGet(p.FoodID);
            x.Name = p.Name;
            x.Description = p.Description;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.Stock = p.Stock;           
            x.CategoryID = p.CategoryID;
            repository.TUpdate(x);

            return RedirectToAction("Index");
        }

        //***********************************************************

    }
}
