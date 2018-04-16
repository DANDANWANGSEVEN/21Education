using _21Education.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.IO;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class CommonController : Controller
    {
        public static readonly string fileSavePath = ConfigurationHelper.GetAppSetting("FileUploadPath").EndsWith("/") ? ConfigurationHelper.GetAppSetting("FileUploadPath") : ConfigurationHelper.GetAppSetting("FileUploadPath") + "/";
        [HttpPost]
        public JsonResult Upload()
        {
            var files = Request.Files;
            List<string> filesPath = new List<string>();
            if (files == null || files.Count == 0) return Json(new { errno = 1 });
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var fileName = string.Format("{0}.{1}", Guid.NewGuid(), files[i].FileName.Split('.')[1]);
                    var physicalPath = Server.MapPath(fileSavePath);
                    if (!Directory.Exists(physicalPath))
                    {
                        Directory.CreateDirectory(physicalPath);
                    }
                    var savePath = physicalPath + fileName;
                    files[i].SaveAs(savePath);
                    filesPath.Add(fileSavePath + fileName);
                }
            }
            catch (Exception)
            {
                return Json(new { errno = 1 });
                throw;
            }
            return Json(new { errno = 0, Message = "上传成功", data = filesPath.ToArray() });
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

