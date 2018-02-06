using _21Education.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.IDAL
{
    public  interface ISysModule
    {

        List<SysModule> GetMenuByPersonId(string moduleId);
    }
}
