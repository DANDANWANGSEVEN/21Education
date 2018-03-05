using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class PositionController : BasicController<ContactPositionInfo, IContactPositionInfo>
    {
        public PositionController(IContactPositionInfo service) : base(service)
        {
        }
    }
}
