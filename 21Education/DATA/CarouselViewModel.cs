using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.MODEL;
namespace _21Education.DATA
{
    public class CarouselViewModel : List<Carousel>
    {
        public CarouselViewModel(List<Carousel> list) : base(list)
        {

        }
        public int ImgWidth { get; set; }
    }
}
