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
        public static T CopyTo(T source, T copyTo, bool withPrimaryKey = false)
        {
            var properties = typeof(T).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (!withPrimaryKey) if (prop.Name == "Id") continue;

                prop.SetValue(copyTo, prop.GetValue(source));

            }
            return copyTo;
        }

        public static IEnumerable<T> SearchListByString(List<T> sourceList, string searchString)
        {
            var properties = typeof(T).GetProperties().ToList().Where(e => e.PropertyType == typeof(string));
            foreach (var item in sourceList)
            {
                if (properties
                    .Where(e => (e.GetValue(item) as string) != null && (e.GetValue(item) as string).Contains(searchString))
                    .Any())
                    yield return item;
            }
        }
    }
}
