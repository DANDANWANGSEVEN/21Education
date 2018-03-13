using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _21Education.Converter
{
    public class DateTimeConverter
    {
        /// <summary>
        /// 将Json序列化的时间由/Date(1294499956278+0800)转为字符串
        /// </summary>
        public static string ConvertJsonDateToDateString(Match m)
        {

            string result = string.Empty;

            string p = @"\d";
            var cArray = m.Value.ToCharArray();
            StringBuilder sb = new StringBuilder();

            Regex reg = new Regex(p);
            for (int i = 0; i < cArray.Length; i++)
            {
                if (reg.IsMatch(cArray[i].ToString()))
                {
                    sb.Append(cArray[i]);
                }
            }
            // reg.Replace(m.Value;

            DateTime dt = new DateTime(1970, 1, 1);

            dt = dt.AddMilliseconds(long.Parse(sb.ToString()));

            dt = dt.ToLocalTime();

            result = dt.ToString("yyyy-MM-dd HH:mm:ss");

            return result;

        }

    }
}
