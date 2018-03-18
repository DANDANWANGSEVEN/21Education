using _21Education.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class CommonController : Controller
    {
        public static readonly string fileSavePath = ConfigurationHelper.GetAppSetting("FileUploadPath").EndsWith("/") ? ConfigurationHelper.GetAppSetting("FileUploadPath") : ConfigurationHelper.GetAppSetting("FileUploadPath") + "/";
        [HttpPost]
        public JsonResult Upload()
        {
            var file = Request.Files[0];
            if (file == null || file.InputStream.Length == 0) return Json(new { Code = 1, Message = "上传文件错误" });
            var fileName = string.Format("{0}.{1}", Guid.NewGuid(), file.FileName.Split('.')[1]);
            var savePath = fileSavePath + fileName;
            file.SaveAs(savePath);
            return Json(new { Code = 0, Message = "上传成功", FileName = fileName });
        }

        public JsonResult Delete()
        {
            var file = Request.Files[0];
            if (file == null || file.InputStream.Length == 0) return Json(new { Code = 1, Message = "上传文件错误" });
            var fileName = string.Format("{0}.{1}", Guid.NewGuid(), file.FileName.Split('.')[1]);
            var savePath = Server.MapPath(fileSavePath.EndsWith("/") ? fileSavePath : fileSavePath + "/") + fileName;
            file.SaveAs(savePath);
            return Json(new { Code = 0, Message = "上传成功", FileName = fileName });
        }
    }
}

