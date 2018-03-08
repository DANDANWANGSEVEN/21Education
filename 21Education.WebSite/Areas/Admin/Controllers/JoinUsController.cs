using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class JoinUsController : BasicController<ContactRecruitInfo, IContactRecruitInfo>
    {
        public JoinUsController(IContactRecruitInfo service) : base(service)
        {
        }
    }
}
