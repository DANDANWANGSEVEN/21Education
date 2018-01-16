using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.MODEL;
namespace _21Education.DAL
{

    public class _21EducationDbContext : DbContext
    {
        public _21EducationDbContext()
            : base("name=_21Education")
        {

        }
        public DbSet<News> News { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<Carousel> Carousel { set; get; }
    }
}
