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
 //               IApp app = ConfigureApp
 //                   .Android
   //                 .ApkFile("E:/Xamarin Stage/Test UI automatique/AppforUItest/AppTest/AppTest/AppTest.Android/bin/Debug/com.companyname.App3-Signed.apk")
    //                .StartApp();
                 return ConfigureApp.Android.EnableLocalScreenshots().ApkFile("/Users/Shared/Jenkins/Home/workspace/build_project/AppTest/AppTest.Android/bin/Debug/com.companyname.AppTest.apk").StartApp(Xamarin.UITest.Configuration.AppDataMode.DoNotClear);
       //           return ConfigureApp.Android.DeviceSerial("420088e7f4f1b300").ApkFile("E:/Xamarin Stage/AppConversionUITest/AppTest/AppTest/AppTest.Android/bin/Debug/com.companyname.AppTest.apk").StartApp();

            }
            return ConfigureApp.iOS.AppBundle("/Users/Shared/Jenkins/Home/workspace/build_project/AppTest/AppTest.iOS/bin/iPhoneSimulator/Debug/AppTest.iOS.app").PreferIdeSettings().StartApp(Xamarin.UITest.Configuration.AppDataMode.DoNotClear);
        }
    }
}
