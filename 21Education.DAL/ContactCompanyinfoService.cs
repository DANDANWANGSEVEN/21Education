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
    public class ContactCompanyinfoService : ServiceBase<MODEL.ContactCompanyinfo>, IContactCompanyinfo
    {
        public ContactCompanyinfoService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<ContactCompanyinfo> CurrentDbSet => (DbContext as _21EducationDbContext).ContactCompanyinfo;
    }
}
