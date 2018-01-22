using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace _21Education.IDAL
{
    interface IDataBase<T> where T : DbContext
    {

    }
}
