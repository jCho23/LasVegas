using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace LasVegas
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void FirstTest()
		{
			Thread.Sleep(8000);
			app.Tap("skipButton");
			Thread.Sleep(8000);
			app.Screenshot("Lets tap the 'Close' Button");

			Thread.Sleep(8000);
			app.Tap(x => x.Marked("textSection").Index(0));
			Thread.Sleep(8000);
			app.Screenshot("Then, We Tapped on the first news tile");
			Thread.Sleep(8000);
			app.Back();
			Thread.Sleep(8000);
			app.Screenshot("We Tapped on the 'Back' Button");

			app.Tap(x => x.Marked("textSection").Index(1));
			Thread.Sleep(8000);
			app.Screenshot("Next, we Tapped on the second news tile");
			Thread.Sleep(8000);
			app.Back();
			Thread.Sleep(8000);
			app.Screenshot("We Tapped on the 'Back' Button");

			app.Tap("searchButtonBackground");
			Thread.Sleep(8000);
			app.Screenshot("We Tapped on the 'Search' icon");
			app.Query(x => x.Class("android.widget.EditText").Invoke("setText", "microsoft"));
			Thread.Sleep(8000);
			app.Screenshot("We entered in our search, 'Microsoft'");
			Thread.Sleep(8000);
			app.PressEnter();
			app.Screenshot("Then, we Tapped on the enter button");
			Thread.Sleep(8000);

			app.Tap("Business");
			Thread.Sleep(8000);
			app.Screenshot("We Tapped the result that came up");

			app.ScrollDown();
			Thread.Sleep(8000);
			app.Screenshot("Scrolling down for more information");
			Thread.Sleep(8000);

			app.WaitForElement(x=>x.Marked("backButton"), timeout:TimeSpan.FromSeconds(30000));
			app.Tap("backButton");
			Thread.Sleep(8000);
			app.Screenshot("We Tapped on the 'Back' Button");

			Thread.Sleep(8000);
			app.Tap("homeButtonBackground");
			Thread.Sleep(8000);
			app.Screenshot("Lastly, we Tapped on the 'Home' icon");
		}

	}
}
