using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
 //   [TestFixture(Platform.iOS)]
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
            /*Test si la conversion en dollar marche*/
            /*AutomationID sert a créer un ID pour les testes */

            //Arrange (setup test)
            app.EnterText("ValueMoney", "5"); //Entre 5 dans l'entry id : ValueMoney

            //Act (perform test)
            app.Tap("DollarButton");

            //Assert (verify test)
            var appResult = app.Query("ResultLabel").First(result => result.Text == "5.8 $");
            Assert.IsTrue(appResult != null, "Dollar conversion don't work !");

        }
        [Test]
        public void Livre_Work_Conversion()
        {

            app.EnterText("ValueMoney", "580.23");
            app.Tap("LivreButton");
            var appResult = app.Query("ResultLabel").First(result => result.Text == "522.207 £");
            Assert.IsTrue(appResult != null, "Livre conversion don't work");
            app.Screenshot("when is finish");

        }
        [Test]
        public void Reset_Button_Work()
        {

            app.EnterText("ValueMoney", "87883949384");
            app.Tap("LivreButton");
            app.Tap("ResetButton");
            var appResult = app.Query(x => x.Marked("ValueMoney")?.Invoke("placeholder"))?.FirstOrDefault()?.ToString();

            Assert.IsTrue(appResult != null, "Reset button don't work");

        }
    }
}
