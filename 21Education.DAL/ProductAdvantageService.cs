using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.Repository;
using _21Education.MODEL;
using _21Education.IDAL;
using System.Data.Entity;

namespace _21Education.DAL
{
    public class ProductAdvantageService : ServiceBase<ProductAdvantage>, IProductAdvantange
    {
        public ProductAdvantageService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<ProductAdvantage> CurrentDbSet => (DbContext as _21EducationDbContext).ProductAdvantage;
        
    }
}
