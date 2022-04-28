using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarouselViewTester
{
    internal class NextPageTabCarousel : ContentPage
    {
        class ImageData
        {
            public ImageSource ImageSource { get; set; }
        }

        List<ImageData> imageDatas;
        public NextPageTabCarousel()
        {
            imageDatas = new List<ImageData>();

            var fullFilename = ZippedFiles.GetFullFilename("austonomus_australis_head.jpg");
            if (File.Exists(fullFilename))
            {
                var imageSource = ImageSource.FromFile(fullFilename);
                imageDatas.Add(new ImageData { ImageSource = imageSource });
            }

            fullFilename = ZippedFiles.GetFullFilename("austonomus_australis2.jpg");
            if (File.Exists(fullFilename))
            {
                var imageSource = ImageSource.FromFile(fullFilename);
                imageDatas.Add(new ImageData { ImageSource = imageSource });
            }


            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            var carouselView = new CarouselView();
            carouselView.ItemsSource = imageDatas;

            carouselView.ItemTemplate = new DataTemplate(() =>
            {

                var image = new Image
                {
                    Aspect = Aspect.AspectFit,
                };

                image.SetBinding(Image.SourceProperty, new Binding(nameof(ImageData.ImageSource), BindingMode.OneWay));

                return image;
            });

            var indicatorView = new IndicatorView
            {
                IndicatorColor = Colors.LightGray,
                SelectedIndicatorColor = Colors.Red,
                HorizontalOptions = LayoutOptions.Center,
                IndicatorsShape = IndicatorShape.Square,
                IndicatorSize = 18
            };
            carouselView.IndicatorView = indicatorView;

            var mainLayout = new Grid();
            mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            mainLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            mainLayout.Add(carouselView, 0, 0);
            mainLayout.Add(indicatorView, 0, 1);

            var innerLayout = new FlexLayout();
            innerLayout.Children.Add(carouselView);

            var outerlayout = new FlexLayout() { Margin = 10 };
            outerlayout.Direction = FlexDirection.Column;
            outerlayout.Children.Add(innerLayout);
            outerlayout.Children.Add(indicatorView);

            FlexLayout.SetGrow(innerLayout, 1);
            FlexLayout.SetGrow(carouselView, 1);


            Title = "Carousel";
            Content = outerlayout;
        }
    }
}
