using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entity.Concrete;

namespace Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
