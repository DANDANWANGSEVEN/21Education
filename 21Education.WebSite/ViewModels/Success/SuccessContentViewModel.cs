using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21Education.MODEL;

namespace _21Education.WebSite.ViewModels
{
    public class SuccessContentViewModel
    {
        public Success CurrentSuccess { get; set; }

        public Success PrevSuccess { get; set; }

        public Success NextSuccess { get; set; }
    }
}