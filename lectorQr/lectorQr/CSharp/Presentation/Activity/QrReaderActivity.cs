using System;
using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using ZXing.Mobile;

namespace lectorQr.CSharp.Presentation.Activity
{
    [Activity(Label = "Lector Qr", Theme = "@style/AppTheme")]
    public class QrReaderActivity : AppCompatActivity
    {
        Button enterButton;
        TextView codeText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_qr_reader);
            codeText = FindViewById<TextView>(Resource.Id.codeText);
            enterButton = FindViewById<Button>(Resource.Id.enterButton);
            enterButton.Click += btnQrReaderClick;
        }

        private async void btnQrReaderClick(object sender, EventArgs e)
        {
            MobileBarcodeScanner.Initialize(Application);
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
                codeText.Text = result.Text;
        }
    }
}
