using _21Education.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _21Education.WebSite.ViewModels
{
    public class ProductsListViewModel : PaginationViewModel<MODEL.Product>
    {
        public ProductsListViewModel(List<MODEL.Product> productList) : base(productList)
        {

        }
        public Pagination Pagination { set; get; }
        
    }
}