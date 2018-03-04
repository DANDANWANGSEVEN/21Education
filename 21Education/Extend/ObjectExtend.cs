using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _21Education
{
    public static class TypeExtend<T>
    {
        public static T CopyTo( T source, T copyTo)
        {
            var properties = typeof(T).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (prop.Name!="Id")
                prop.SetValue(copyTo, prop.GetValue(source));
            }
            return copyTo;
        }

        public static IEnumerable<T> SearchListByString(List<T> sourceList, string searchString)
        {
            var properties = typeof(T).GetProperties().ToList().Where(e=>e.PropertyType==typeof(string));
            foreach (var item in sourceList)
            {
                foreach (PropertyInfo prop in properties)
                {
                    if((prop.GetValue(item) as string).Contains(searchString)) yield return item;
                }
            }
        }
    }
}
