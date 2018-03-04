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

        public override DbSet<SysModule> CurrentDbSet => (DbContext as _21EducationDbContext).SysModule;




        //_21EducationDbContext _21EducationDbContext;

        //public SysDAL(_21EducationDbContext _21EducationDbContext)
        //{
        //    this._21EducationDbContext = _21EducationDbContext;
        //}

        //public List<SysModule> GetMenuByPersonId(string moduleId)
        //{
        //    throw new NotImplementedException();
        //}


        //public List<SysModule> GetMenuByPersonId(string moduleId)
        //{
        //    using (var db = new _21EducationDbContext())
        //    {
        //        var menus =
        //        (
        //            from m in db.SysModule
        //            where m.ParentId == moduleId
        //            where m.Id != "0"
        //            select m
        //                  ).Distinct().OrderBy(a => a.Sort).ToList();
        //        return menus;
        //    }
        //}

    }
}
