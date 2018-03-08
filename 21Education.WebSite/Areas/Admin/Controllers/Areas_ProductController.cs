using _21Education.MODEL;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_ProductController : BasicController<Product, IProduct>
    {
        public Areas_ProductController(IProduct service) : base(service)
        {
        }
    }
}
