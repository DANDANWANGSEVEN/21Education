using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21Education.DATA;
using _21Education.MODEL;

namespace _21Education.WebSite.ViewModels
{
    public class FriendlyListViewModel
    {
        public List<FriendlyLink> friendlylinks { get; set; }

        public List<Product> products { get; set; }
    
    }
}