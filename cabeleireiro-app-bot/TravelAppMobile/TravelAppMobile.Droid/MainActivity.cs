using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using CabeleireiroAppMobile.Utils;

namespace CabeleireiroAppMobile.Droid
{
    [Activity(Label = "CabeleireiroAppMobile", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            GetScreenSize();
        }


        private void GetScreenSize()
        {
            var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;

            ScreenSize.Width = (width - 0.5f) / density;
            ScreenSize.Height = (height - 0.5f) / density;
        }
    }
}

