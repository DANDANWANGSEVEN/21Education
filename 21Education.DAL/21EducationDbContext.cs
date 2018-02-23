using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.MODEL;
namespace _21Education.DAL
{

    public class _21EducationDbContext : DbContext
    {
        public _21EducationDbContext()
            : base("name=_21Education")
        {

        }
        #region 首页
        public DbSet<Carousel> Carousel { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<IndexMainBusiness> IndexMainBusiness { set; get; }
        public DbSet<IndexAdvantage> IndexAdvantage { set; get; }
        public DbSet<News> News { set; get; }
        public DbSet<Success> Success { set; get; }
        #endregion

        #region 关于我们
        public DbSet<AboutCompanyProfile> AboutCompanyProfile { set; get; }
        public DbSet<AboutCompanyHonor> AboutCompanyHonor { set; get; }
        public DbSet<AboutCompanyCulture> AboutCompanyCulture { set; get; }
        public DbSet<AboutCompanyAchievement> AboutCompanyAchievement { set; get; }
        #endregion

        #region 联系我们
        public DbSet<ContactCompanyinfo> ContactCompanyinfo { set; get; }
        public DbSet<ContactCooperateinfo> ContactCooperateinfo { set; get; }
        public DbSet<ContactRecruitInfo> ContactRecruitInfo { set; get; }
        public DbSet<ContactPositionInfo> ContactPositionInfo { set; get; }
        #endregion

        #region 后台用户管理
        public DbSet<UserInfo> UserInfo { set; get; }
        #endregion

        #region 后台树形

        //public DbSet<SysModule> SysModule { set; get; }

        #endregion

    }
}
