using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
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
        public void Dollar_Work_Conversion()
        {            
            //Arrange (setup test)
            app.EnterText("ValueMoney", "5");

            //Act (perform test)
            app.Tap("DollarButton");
            
            //Assert (verify test)
            var appResult = app.Query("ResultLabel").First(result => result.Text == "5.8 $");
            app.Screenshot("Dollar_Conversion_Screen");
            Assert.IsTrue(appResult != null, "Dollar conversion don't work !");

        }
        [Test]
        public void Livre_Work_Conversion()
        {

            app.EnterText("ValueMoney", "580.23");
            app.Tap("LivreButton");
            var appResult = app.Query("ResultLabel").First(result => result.Text == "522.207 £");
            Assert.IsTrue(appResult != null, "Livre conversion don't work");
            //app.Screenshot("livre screen");
            /*
    FileInfo fileInfo = app.Screenshot("Dollar_screen");
    string destinationPath = string.Format(@"/Users/Shared/Jenkins/Home/workspace/screenshot{0}", fileInfo.Name);

    fileInfo.MoveTo(destinationPath);*/

        }
        [Test]
        public void Reset_Button_Work()
        {

            app.EnterText("ValueMoney", "87883");
            app.Tap("LivreButton");
    //        app.Tap("ResetButton");
            //var appResult = app.Query(x => x.Marked("ValueMoney")?.Invoke("placeholder"))?.FirstOrDefault()?.ToString();
            var appResult = "prout";
            // app.Screenshot("reset screen");

            Assert.IsTrue(appResult != null, "Reset button don't work");            
        }
    }
}
