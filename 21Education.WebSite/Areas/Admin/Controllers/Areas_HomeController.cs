
using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_HomeController : BasicController<Carousel, ICarousel>
    {
        public Areas_HomeController(ICarousel service) : base(service)
        {

        }
    }
}
