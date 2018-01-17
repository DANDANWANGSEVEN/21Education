using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.DATA
{
    public abstract class PaginationViewModel<T> : List<T>
    {
        public PaginationViewModel(List<T> list) : base(list)
        {

        }
        Pagination Pagination { set; get; }
    }
}
