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
    public class AboutCompanyAchievementService : ServiceBase<AboutCompanyAchievement>, IAboutCompanyAchievementService
    {
        AboutCompanyAchievementService(_21EducationDbContext dbContext) : base(dbContext)
        {

        }
        public override DbSet<AboutCompanyAchievement> CurrentDbSet => (DbContext as _21EducationDbContext).AboutCompanyAchievement;
    }
}
