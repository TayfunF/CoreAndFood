using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Repositories;
using CoreAndFood.Data.Models;

namespace CoreAndFood.ViewComponents
{
    //ViewComponente ait özellikleri burada kullanabilmek için tanımladım.
    //Web uygulamalarımızda birden fazla alanda
    //kullanmak istediğimiz viewlerimiz için ViewComponent’i tercih edebilrim.
    //Burada ben sol sidebar(menü) olarak kulladım.
    //ViewComponent Adımları 
    // 1-) Proje de ViewComponents adında klasör oluştur.
    // 2-) Bu klasör içerisine CategoryGetList.cs adında class oluştur.
    // 3-) Proje de default adında bir klasör oluştur.
    // 4-) Bu klasör içerisine Components adında bir klasör oluştur.
    // 5-) Bu klasörün içerisine CategoryGetList adında bir klasör oluştur.
    // 6-) Bu klasörün içerisine Default.cshtml adında bir View oluştur.
    public class CategoryGetList : ViewComponent
    {
        private readonly Context _context;
        CategoryRepository repository;
        public CategoryGetList (Context context)
        {
            _context = context;
            repository = new CategoryRepository(_context);
        }
        public IViewComponentResult Invoke()
        {
            var categorylist = repository.TList();

            return View(categorylist);
        }
    }
}
