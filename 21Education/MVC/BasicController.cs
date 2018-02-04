using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace _21Education.MVC
{
    public class BasicController<TEntity, TPrimarykey, TService> : Controller
        where TEntity : EditorEntity
        where TService : IService<TEntity>
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(int Id)
        {
            TEntity entity = Activator.CreateInstance<TEntity>();
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
