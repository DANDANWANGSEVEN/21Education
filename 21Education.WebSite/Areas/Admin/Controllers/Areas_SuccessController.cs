using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_SuccessController : BasicController<Success, ISuccess>
    {
        public Areas_SuccessController(ISuccess service) : base(service)
        {
        }
    }
}
