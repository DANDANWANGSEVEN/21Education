
using _21Education.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.DAL;
namespace _21Education.BLL
{
    public class SysBLL
    {
        public SysBLL(_21EducationDbContext  _21EducationDbContext)
        {
            sysdal = new SysDAL(_21EducationDbContext);
        }
        _21Education.DAL.SysDAL sysdal;

        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            try
            {
                return sysdal.GetMenuByPersonId(moduleId);
            }
            catch(Exception ex)
            {
                return null;
            }
        }






    }
}
