using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.DAL;
using _21Education.MODEL;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
namespace _21Education.DALTest
{
    class Program
    {
        public class Initializer : DropCreateDatabaseIfModelChanges<_21EducationDbContext>
        {

        }
        static void Main(string[] args)
        {
            //using (var context=new _21EducationDbContext())
            //{
            //    context.Database.CreateIfNotExists();


            //    Database.SetInitializer(new Initializer());
            //    context.News.Add(new News {Content="ashdadnnjada",ImgPath="asdfa",PubDate=DateTime.Now,ReadCount=123,Title="title" });

            //    context.SaveChanges();
            //}
            //var dal = new SysDAL();
            //var model= dal.GetMenuByPersonId("0");

            Console.ReadLine();
        }

    }
}
