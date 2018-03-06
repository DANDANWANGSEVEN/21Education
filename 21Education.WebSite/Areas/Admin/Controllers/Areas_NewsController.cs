using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_NewsController : BasicController<News, INewsService>
    {
        public Areas_NewsController(INewsService service) : base(service)
        {
        }
    }
}
