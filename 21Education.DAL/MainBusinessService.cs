using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.IDAL;
using _21Education.Repository;
using _21Education.MODEL;
using System.Data.Entity;

namespace _21Education.DAL
{
    public class MainBusinessService : ServiceBase<IndexMainBusiness>, IndexMainBusinessIDAL
    {
        public MainBusinessService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<IndexMainBusiness> CurrentDbSet => (DbContext as _21EducationDbContext).IndexMainBusiness;
    }
}
