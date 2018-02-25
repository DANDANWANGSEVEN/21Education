using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.DataBase
{
    public class DataBaseInitializer<TContext> : DropCreateDatabaseIfModelChanges<TContext> where TContext : DbContext
    {
    }
}
