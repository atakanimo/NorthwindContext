using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entity.Concrete;

namespace Northwind.DataAccess.Concrete
{
    public class CategoryDal : EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {

    }
}
