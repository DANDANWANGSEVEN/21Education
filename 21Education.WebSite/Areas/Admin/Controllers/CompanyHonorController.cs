using _21Education.MVC;
using _21Education.IDAL;
using _21Education.MODEL;


namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class CompanyHonorController : BasicController<AboutCompanyHonor, IAboutCompanyHonor>
    {
        public CompanyHonorController(IAboutCompanyHonor service) : base(service)
        {
        }
    }
}
