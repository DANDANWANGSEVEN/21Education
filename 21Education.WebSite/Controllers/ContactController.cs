using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.IDAL;
namespace _21Education.WebSite.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        IContactCompanyinfo _contactcompanyinfo;
        IContactCooperateinfo _contactcooperateinfo;
        IContactRecruitInfo _contactrecruitinfo;
        IContactPositionInfo _contactpositioninfo;
        public ContactController(IContactCompanyinfo contactcompanyinfo, IContactCooperateinfo contactcooperateinfo, IContactRecruitInfo contactrecruitinfo, IContactPositionInfo contactpositioninfo)
        {
            _contactcompanyinfo = contactcompanyinfo;
            _contactcooperateinfo = contactcooperateinfo;
            _contactrecruitinfo = contactrecruitinfo;
            _contactpositioninfo = contactpositioninfo;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region 联系我们页面
        public ActionResult ContactUs()
        {
            //公司信息
            var companyinfoList = _contactcompanyinfo.Get().OrderBy(e=>e.ContactCompanyinfoId).ToList();
            ViewBag.companyinfoListShow = companyinfoList;

            //公司合作
            var cooperateinfoList = _contactcooperateinfo.Get().OrderBy(e => e.ContactCooperateinfoId).ToList();
            ViewBag.cooperateinfoListShow = cooperateinfoList;

            //招聘信息
            var recruitinfoList = _contactrecruitinfo.Get().OrderBy(e => e.ContactRecruitInfoId).ToList();
            ViewBag.recruitinfoListShow = recruitinfoList;


            return View();
        }
        #endregion

        #region 招聘信息页面
        public ActionResult JoinUs()
        {
            //招聘信息
            var positioninfoList = _contactpositioninfo.Get().OrderBy(e => e.ContactPositionInfoId).ToList();
            ViewBag.positioninfoListShow = positioninfoList;

            return View();
        }
        #endregion

    }
}
