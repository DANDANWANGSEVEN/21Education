using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.IDAL;
using _21Education.MODEL;
using _21Education.Repository;
namespace _21Education.DAL
{
    public class ProductService : ServiceBase<MODEL.Product>, IProduct
    {
        public ProductService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<Product> CurrentDbSet => (DbContext as _21EducationDbContext).Product;
    }
}
