using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;
namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_ContactController : BasicController<ContactCompanyinfo, IContactCompanyinfo>
    {
        public Areas_ContactController(IContactCompanyinfo service) : base(service)
        {
        }
    }
}
