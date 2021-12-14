using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using frameworks.CSharp.Data;
using frameworks.CSharp.Data.model;
using lectorQr.CSharp.Presentation.Adapter;

namespace lectorQr.CSharp.Presentation.Activity
{  
    [Activity(Label = "Lector Qr",
        Theme = "@style/AppTheme",
        ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class QrListActivity : AppCompatActivity
    {
        LinearLayoutManager layoutManager;
        QrListAdapter adapter;
        RecyclerView qrCodesRecyclerView;
        TextView codeText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_qr_list);
            layoutManager = new LinearLayoutManager(this);
            qrCodesRecyclerView = FindViewById<RecyclerView>(Resource.Id.qrCodesRecyclerView);
            codeText = FindViewById<TextView>(Resource.Id.codeText);
            showList();
        }

        private void showList()
        {
            var codeList = DataManager.RealmInstance.All<CodeQr>().ToList();
            if (codeList == null || codeList.Count == 0)
            {
                codeText.Text = GetString(Resource.String.empty_code);
                codeText.Visibility = ViewStates.Visible;
            }
            else
            {
                setRecyclerView(codeList);
            }
        }

        private void setRecyclerView(List<CodeQr> qrCodeList)
        {
            adapter = new QrListAdapter(this, qrCodeList);
            qrCodesRecyclerView.SetAdapter(adapter);
            qrCodesRecyclerView.SetLayoutManager(layoutManager);
            qrCodesRecyclerView.Visibility = ViewStates.Visible;
        }
    }
}
