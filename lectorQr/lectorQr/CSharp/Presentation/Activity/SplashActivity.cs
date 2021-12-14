using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using lectorQr.CSharp.Presentation.Activity;
using lectorQr.CSharp.Presentation.Contract;

namespace lectorQr
{
    [Activity(Theme = "@style/Splash", MainLauncher = true)]
    public class SplashActivity : AppCompatActivity, SplashContract
    {      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_splash);
            this.initView();
        }       

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public int initView()
        {
            Task startupWork = new Task(() => {
                Task.Delay(3000);
            });

            startupWork.ContinueWith(async t => {
                StartActivity(new Intent(this, typeof(QrReaderActivity)));
                Finish();
            });

            startupWork.Start();

            return 0;
        }    
    }
}