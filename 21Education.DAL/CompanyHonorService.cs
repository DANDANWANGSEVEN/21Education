using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.Repository;
using _21Education.IDAL;
using System.Data.Entity;
using _21Education.MODEL;

namespace _21Education.DAL
{
    public class CompanyHonorService : ServiceBase<MODEL.AboutCompanyHonor>, IAboutCompanyHonor
    {
        public CompanyHonorService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<AboutCompanyHonor> CurrentDbSet => (DbContext as _21EducationDbContext).AboutCompanyHonor;
    }
}
