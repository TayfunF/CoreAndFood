using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }
        public List<T> TList()
        {
            return _context.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            _context.Set<T>().Add(p);
            _context.SaveChanges();
        }

        public void TDelete(T p)
        {
            _context.Set<T>().Remove(p);
            _context.SaveChanges();
        }
        public void TUpdate(T p)
        {
            _context.Set<T>().Update(p);
            _context.SaveChanges();
        }
        public T TGet(int id)
        {
           return  _context.Set<T>().Find(id);
        }

        //Bu method sadece string bir değere göre listeleme yapmaya yarıyor.
        public List<T> TList(string p)
        {
            return _context.Set<T>().Include(p).ToList();
        }

        // Bu method şu işe yarıyor. 
        // Ben tablomda istediğim herhangi bir sütuna göre arama işlemi yapabilirim.

        public List<T> List(Expression<Func<T,bool>>filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }
    }
}
