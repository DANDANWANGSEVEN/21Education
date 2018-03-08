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
    public class SuccessService : ServiceBase<Success>, ISuccess
    {
        public SuccessService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<Success> CurrentDbSet => (DbContext as _21EducationDbContext).Success;

    }
}
