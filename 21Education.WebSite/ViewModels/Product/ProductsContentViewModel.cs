using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21Education.MODEL;

namespace _21Education.WebSite.ViewModels
{
    public class ProductsContentViewModel
    {
        public Product ProductCurrent { set; get; }

        public Product ProductPrev { set; get; }

        public Product ProductNext { set; get; }

    }
}