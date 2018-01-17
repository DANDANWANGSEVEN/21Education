using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _21Education.COMMON
{
    public static class CustomRegex
    {
        public static Regex PageRegex = new Regex(@"/p(\d+)", RegexOptions.IgnoreCase);

    }
}
