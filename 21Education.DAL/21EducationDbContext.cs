using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.MODEL;
using _21Education.IOC;
using _21Education.DataBase;
using System.Data.Entity.Infrastructure;

namespace _21Education.DAL
{

    public class _21EducationDbContext : DbContext,IDbContextFactory<_21EducationDbContext>, IDependency
    {
        public _21EducationDbContext()
        {

        }
        public _21EducationDbContext(string nameOrConnectionString): base(nameOrConnectionString)
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

        #region 友情链接
        public DbSet<FriendlyLink> FriendlyLink { set; get; }
        #endregion

        #region 后台用户管理
        public DbSet<UserInfo> UserInfo { set; get; }
        #endregion

        #region 后台树形

        public DbSet<SysModule> SysModule { set; get; }


        #endregion

        public _21EducationDbContext Create()
        {
            throw new NotImplementedException();
        }

    }
    public class Initializer : DataBaseInitializer<_21EducationDbContext>
    {
        protected override void Seed(_21EducationDbContext context)
        {
            List<News> newsList = new List<News>();
            for (int i = 0; i < 200; i++)
            {
                newsList.Add(new News { Title = "新闻" + i, PubDate = DateTime.Now, Content = "新闻消息", ImgPath = "/image/about_14.jpg" });
            }
            context.News.AddRange(newsList);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
