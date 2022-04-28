namespace CarouselViewTester;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		ZippedFiles.Extract();
		ZippedFiles.ListAllFiles();	

		MainPage = new NavigationPage(new NextPageTabbed());
	}
}
