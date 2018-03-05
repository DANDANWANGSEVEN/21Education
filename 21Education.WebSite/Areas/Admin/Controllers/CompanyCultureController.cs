using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class CompanyCultureController : BasicController<AboutCompanyCulture, IAboutCompanyCulture>
    {
        public CompanyCultureController(IAboutCompanyCulture service) : base(service)
        {
        }
    }
}
