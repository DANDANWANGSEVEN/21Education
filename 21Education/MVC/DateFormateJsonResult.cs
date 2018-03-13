using _21Education.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace _21Education.MVC
{
    public class DateFormateJson : JsonResult
    {
        public string DateFormat { get; set; }
        public DateFormateJson(object data, JsonRequestBehavior behavior, string dateFormat = null)
        {
            //data.GetType().GetProperties().Where(e => e.GetType() == typeof(DateTime)).ToList().ForEach(e=> {
            //    e.GetCustomAttributes()
            //});
            DateFormat = dateFormat ?? "yyyy-MM-dd HH:mm:ss";
            base.Data = data;
            base.JsonRequestBehavior = behavior;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context);
            var response = context.HttpContext.Response;
            response.Clear();
            if (Data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonstring = serializer.Serialize(Data);

                string p = @"\\/Date\(\d+\)\\/";

                MatchEvaluator matchEvaluator = new MatchEvaluator(DateTimeConverter.ConvertJsonDateToDateString);

                Regex reg = new Regex(p);

                jsonstring = reg.Replace(jsonstring, matchEvaluator);
                response.Write(jsonstring);
            }
        }
    }
}
