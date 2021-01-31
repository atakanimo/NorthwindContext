using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entity.Concrete;

namespace Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        void Update(Product entity);
        void Add(Product entity);
        void Delete(Product entity);
        List<Product> FindbyKey(string key);
        List<Product> FindbyCategory(int id);
    }
}
