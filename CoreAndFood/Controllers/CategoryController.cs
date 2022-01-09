using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        //Context & CONSTRUCTOR & CategoryRepository SUBJECT TANIMLAMA
        private readonly Context _context;
        CategoryRepository repository;

        public CategoryController(Context context)
        {
            _context = context;
            repository = new CategoryRepository(_context);
        }

        //***********************************************************

        //Category Home Page & Pagination
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
        /* Sayfalama yerine arama kısmını ekledim buraya.
         Sayfalama FoodControlerda var*/
       
        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(repository.List(x => x.CategoryName == p));
            }
            return View(repository.TList());
        }

        //***********************************************************

        //A New Category Page [GET]
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        //A New Category Page [POST]
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            //Alan boş bırakılmadıysa CategoryAdd sayfasına git
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            repository.TAdd(p);
            return RedirectToAction("Index");
        }

        //***********************************************************

        //Category List Page & Use To Dropdownlist 
        public IActionResult CategoryGet(int id)
        {
            var x = repository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryID = x.CategoryID
            };
            return View(ct);
        }

        //***********************************************************

        //Category Update Page [POST]
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = repository.TGet(p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;
            x.Status = true;
            repository.TUpdate(x);
            return RedirectToAction("Index");
        }

        //***********************************************************
        // İLİŞKİLİ TABLO OLDUĞU İÇİN
        // .NET CORE 'DA DİREK SİLME YAPILAMIYOR
        // BU YÜZDEN AKTİF PASİF DURUMUNU KULLANIYORUZ
        // SİLMEK İSTEDİĞİMİZ ŞEYİ SİLİNCE STATUSU FALSE 'A DÖNÜYOR
        // VERİ TABANINDAN SİLİNİYOR AMA WEB SAYFASINDA STATUS KISMI FALSE OLUYOR
        public IActionResult CategoryRemove(int id)
        {
            var x = repository.TGet(id);
            x.Status = false;
            repository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
