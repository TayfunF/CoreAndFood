using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.ViewComponents
{
    public class FoodListByCategory :ViewComponent
    {
        private readonly Context _context;
        FoodRepository repository;

        public FoodListByCategory(Context context)
        {
            _context = context;
            repository = new FoodRepository(_context);
        }

        //Ürünlerin listesini CategoryDetails sayfasında göstermek için
        public IViewComponentResult Invoke(int id)
        {
            //id=1 yazarsak sadece meyveleri getiricekti. O yüzden açıklama saırı yaptım.
            //id = 1;
            var foodlist = repository.List(x=>x.CategoryID==id);
            return View(foodlist);
        }
    }
}
