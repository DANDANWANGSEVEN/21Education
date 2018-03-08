using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.DAL;
using _21Education.IDAL;
using _21Education.MODEL;
using _21Education.Repository;

namespace _21Education.DAL
{

    public class SysDAL : ServiceBase<SysModule>, ISysModule
    {
        public SysDAL(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            return null;
        }



        public override DbSet<SysModule> CurrentDbSet => (DbContext as _21EducationDbContext).SysModule;



    }
}
