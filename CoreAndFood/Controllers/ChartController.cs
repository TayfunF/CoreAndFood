using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    
    public class ChartController : Controller
    {
        private readonly Context _context;
        public ChartController(Context context)
        {
            _context = context;
        }

        //STATİK GOOGLE CHART PIE (CIRCLE) İÇİN KODLAR
        // Index() ve Index2() statik olarak yapımı
        public IActionResult Index()
        {
            return View();
        }

        //***********************************************

        //STATİK GOOGLE CHART COLUMN (SÜTUN) İÇİN KODLAR
        public IActionResult Index2()
        {
            return View();
        }

        //***********************************************

        //STATİK GOOGLE CHART İÇİN KODLAR

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<StatikChart> ProList()
        {
            List<StatikChart> cs = new List<StatikChart>();
            cs.Add(new StatikChart()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new StatikChart()
            {
                proname = "Lcd",
                stock = 75
            });

            cs.Add(new StatikChart()
            {
                proname = "Usb Disk",
                stock = 220
            });
            return cs;
        }

        //***********************************************

        //LINQ EGZERSİZLERİ
        //İSTATİSTİK SAYFASINI YAPMAK İÇİN KODLAR
        //HANGİ ÜRÜNDEN NE KADAR VAR SAYISINI GÖSTERME VS.
        //BU DEĞERLERİ Statistics.cshtml İçerisinde Viewbag yardımıyla kullandım.

        public IActionResult Statistics()
        {
            //VERİ TABANINDAKİ TOPLAM YİYECEKLERİN SAYISI
            var deger1 = _context.Foods.Count();
            ViewBag.d1 = deger1;

            //VERİ TABANINDAKİ TOPLAM KATEGORİLERİN SAYISI
            var deger2 = _context.Categories.Count();
            ViewBag.d2 = deger2;

            //Food ve Vegetables'in ID lerini kendimiz girmek yerine 
            //bir foodid değişkeninde tutarak onu gönderiyoruz.
            var foodid = _context.Categories.Where(x => x.CategoryName == "Fruit")
                .Select(y => y.CategoryID).FirstOrDefault();
            var deger3 = _context.Foods.Where(x => x.CategoryID == foodid).Count();
            ViewBag.d3 = deger3;

            //Food ve Vegetables'in ID lerini kendimiz girmek yerine 
            //bir foodid değişkeninde tutarak onu gönderiyoruz.
            var foodid2 = _context.Categories.Where(x => x.CategoryName == "Vegetables")
                .Select(y => y.CategoryID).FirstOrDefault();

            var deger4 = _context.Foods.Where(x => x.CategoryID == foodid2).Count();
            ViewBag.d4 = deger4;

            var deger5 = _context.Foods.Sum(x => x.Stock);
            ViewBag.d5 = deger5;

            //foodid ve foodid2 için yazdığım kodun kısa hali de var ;
            var deger6 = _context.Foods.Where(x => x.CategoryID == _context.Categories.Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            var deger7 = _context.Foods.OrderByDescending(x => x.Stock)
                .Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = _context.Foods.OrderBy(x => x.Stock)
                .Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = _context.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = deger9;

            var deger10 = _context.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            var deger10p = _context.Foods.Where(y => y.CategoryID == deger10).Sum(x => x.Stock);
            ViewBag.d10 = deger10p;

            var deger11 = _context.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();
            var deger11p = _context.Foods.Where(y => y.CategoryID == deger11).Sum(x => x.Stock);
            ViewBag.d11 = deger11p;

            var deger12 = _context.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.d12 = deger12;

            return View();
        }

    }
}
