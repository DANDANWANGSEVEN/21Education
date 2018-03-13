using _21Education.MODEL;
using _21Education.MVC;
using _21Education.IDAL;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class FriendlylinkController : BasicController<FriendlyLink, IFriendlyLink>
    {
        public FriendlylinkController(IFriendlyLink service) : base(service)
        {
        }
    }
}
