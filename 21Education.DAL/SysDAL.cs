using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.DAL;
using _21Education.IDAL;
using _21Education.MODEL;

namespace _21Education.DAL
{
    public class SysDAL: _21Education.IDAL.ISysModule
    {

      
            public List<SysModule> GetMenuByPersonId(string moduleId)
            {
                using (var db = new _21EducationDbContext())
                {
                    var menus =
                    (
                        from m in db.SysModule
                        where m.ParentId == moduleId
                        where m.Id != "0"
                        select m
                              ).Distinct().OrderBy(a => a.Sort).ToList();
                    return menus;
                }
            }

    }
}
