using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarouselViewTester
{
    internal class NextPageTabbed : TabbedPage
    {
        public NextPageTabbed()
        {

            Children.Add(new NextPageTabCarousel());
            Children.Add(new NextPageTab2());
            Children.Add(new NextPageTab3());

            Title = "TabbedPage";
        }
    }
}
