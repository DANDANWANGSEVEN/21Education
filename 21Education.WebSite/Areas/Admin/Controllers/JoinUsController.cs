using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class JoinUsController : BasicController<ContactPositionInfo, IContactPositionInfo>
    {
        public JoinUsController(IContactPositionInfo service) : base(service)
        {
        }
    }
}
