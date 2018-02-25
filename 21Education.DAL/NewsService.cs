using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.Repository;
using _21Education.MODEL;
using System.Data.Entity;
using _21Education.IDAL;
namespace _21Education.DAL
{
    public class NewsService : ServiceBase<News>, INewsService
    {
        public NewsService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<News> CurrentDbSet => (DbContext as _21EducationDbContext).News;
    }
}
