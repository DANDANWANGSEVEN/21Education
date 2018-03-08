using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _21Education.Repository;
using _21Education.IDAL;
using System.Data.Entity;
using _21Education.MODEL;

namespace _21Education.DAL
{
    public class CarouselService : ServiceBase<MODEL.Carousel>, ICarousel
    {
        public CarouselService(_21EducationDbContext dbContext) : base(dbContext)
        {
        }

        public override DbSet<Carousel> CurrentDbSet => (DbContext as _21EducationDbContext).Carousel;
    }
}
