using _21Education.MVC;
using _21Education.MODEL;
using _21Education.IDAL;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class CompanyCooperateController : BasicController<ContactCooperateinfo, IContactCooperateinfo>
    {
        public CompanyCooperateController(IContactCooperateinfo service) : base(service)
        {
        }
    }
}
