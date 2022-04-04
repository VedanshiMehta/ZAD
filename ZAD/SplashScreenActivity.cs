using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher =true)]
    public class SplashScreenActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.splashScreenLayout);
            SimulateStartup();
        }

        private async void SimulateStartup()
        {
            await Task.Delay(2);
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}