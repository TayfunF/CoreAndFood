using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.ViewComponents
{
    public class FoodGetList :ViewComponent
    {
        private readonly Context _context;
        FoodRepository repository;
        public FoodGetList (Context context)
        {
            _context = context;
            repository = new FoodRepository(_context);
        }

        public IViewComponentResult Invoke()
        {
            var foodlist = repository.TList();
            return View(foodlist);
        }
    }
}
