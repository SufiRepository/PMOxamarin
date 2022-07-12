using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content.Res;
using Acr.UserDialogs;
using Plugin.Permissions;

namespace PMOApp.Droid
{
    [Activity(Label = "PMOApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public override Resources Resources //INI UNTUK CONTROL DEFAULT TEXT YANG FOLLOW DALAM DEFAULT SYSTEM MOBILE
        {
            get
            {
                Resources resource = base.Resources;
                Configuration configuration = new Configuration();
                configuration.SetToDefaults();
                if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.NMr1)
                {
                    return CreateConfigurationContext(configuration).Resources;
                }
                else
                {
                    resource.UpdateConfiguration(configuration, resource.DisplayMetrics);
                    return resource;
                }
            }
        }

        readonly string[] Permission =
        {
            Android.Manifest.Permission.Camera,
            Android.Manifest.Permission.AccessCoarseLocation,
            Android.Manifest.Permission.AccessFineLocation,
            Android.Manifest.Permission.AccessNetworkState,
            Android.Manifest.Permission.WriteExternalStorage,
            Android.Manifest.Permission.ReadExternalStorage
        };
        const int RequestID = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            UserDialogs.Init(this);
            RequestPermissions(Permission, RequestID);
            Window.SetStatusBarColor(Android.Graphics.Color.Rgb(129, 178, 41));
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}