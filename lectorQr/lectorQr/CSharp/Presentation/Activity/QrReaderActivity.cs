using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using frameworks.CSharp.Data;
using frameworks.CSharp.Data.model;
using ZXing.Mobile;

namespace lectorQr.CSharp.Presentation.Activity
{
    [Activity(Label = "Lector Qr", Theme = "@style/AppTheme")]
    public class QrReaderActivity : AppCompatActivity
    {
        Button enterButton, goQrListButton;
        TextView codeText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_qr_reader);
            codeText = FindViewById<TextView>(Resource.Id.codeText);
            enterButton = FindViewById<Button>(Resource.Id.enterButton);
            goQrListButton = FindViewById<Button>(Resource.Id.goQrListButton);
            enterButton.Click += btnQrReaderClick;
            goQrListButton.Click += btnQrListClick;
        }

        private async void btnQrReaderClick(object sender, EventArgs e)
        {
            MobileBarcodeScanner.Initialize(Application);
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
            {
                saveBdLocal(result);
            }
          
        }

        private async void btnQrListClick(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this, typeof(QrListActivity)));
        }

        private void saveBdLocal(ZXing.Result result)
        {
            var codeQr = new CodeQr
            {
                Code = result.Text
            };

            DataManager.RealmInstance.Write(() =>
            {
                DataManager.RealmInstance.Add(codeQr);
            });

        }
    }
}
