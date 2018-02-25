using System.Collections.Generic;
namespace _21Education.DATA
{
    public class CarouselViewModel : List<CarouselBase>
    {
        int _containerWidth;
        public CarouselViewModel(List<CarouselBase> list) : base(list)
        {
            this.ShowCount = 1;
            this.ContainerWidth = ShowCount * (ImgMargin + ImgWidth) - ImgMargin;
        }
        public int ImgWidth { get; set; }
        public int ImgHeight { get; set; }
        public string PreviewHtml { get; set; }
        public string ClassName { set; get; }
        public int ShowCount { set; get; }
        public int ImgMargin { set; get; }
        public int ContainerWidth { set { _containerWidth = value; } get { if (_containerWidth != 0) return _containerWidth; return ShowCount * (ImgMargin + ImgWidth) - ImgMargin; } }
        
    }
}
