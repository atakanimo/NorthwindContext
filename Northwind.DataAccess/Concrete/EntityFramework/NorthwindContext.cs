using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        private DbSet<Product> Products { get; set; }

        private DbSet<Category> Categories { get; set;}
    }
}
