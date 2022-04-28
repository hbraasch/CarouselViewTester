using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarouselViewTester
{
    internal class NextPageTab2: ContentPage
    {
        public NextPageTab2()
        {
            var image = new Image
            {
                Aspect = Aspect.AspectFill
            };
            var fullFilename = ZippedFiles.GetFullFilename("austonomus_australis_head.jpg");
            if (File.Exists(fullFilename))
            {
                // image.Source = "dory_semoni_facial.jpg"; 
                image.Source = ImageSource.FromFile(fullFilename);
            }

            Title = "Tab2";
            Content = image;
        }
    }
}
