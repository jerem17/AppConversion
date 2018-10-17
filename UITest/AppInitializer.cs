using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                 return ConfigureApp
                     .Android
                     .EnableLocalScreenshots()
                     .ApkFile("./AppTest/AppTest.Android/bin/Debug/com.companyname.AppTest.apk")
                     .StartApp(Xamarin.UITest.Configuration.AppDataMode.DoNotClear);
            }
            return ConfigureApp
                .iOS
                .DeviceIdentifier("3BA886C2-B528-4965-BEBD-EEFBAD5BC177")
                .AppBundle("./AppTest/AppTest.iOS/bin/iPhoneSimulator/Debug/AppTest.iOS.app")
                .EnableLocalScreenshots()
                .StartApp(Xamarin.UITest.Configuration.AppDataMode.DoNotClear);            
        }
    }
}
