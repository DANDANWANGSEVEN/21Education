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
    public class SysModuleService : ServiceBase<MODEL.SysModule>, ISysModule
    {
        public SysModuleService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<SysModule> CurrentDbSet => (DbContext as _21EducationDbContext).SysModule;


        public override void Update(SysModule item, bool saveImmediately = true)
        {
            var editModel = CurrentDbSet.Find(item.MId);
            TypeExtend<SysModule>.CopyTo(item, editModel);
            if (saveImmediately)
            {
                SaveChanges();
            }
        }


    }
}
