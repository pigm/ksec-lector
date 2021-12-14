using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using frameworks.CSharp.Data;
using frameworks.CSharp.Data.model;

namespace lectorQr.CSharp.Presentation.Activity
{  
    [Activity(Label = "Lector Qr",
        Theme = "@style/AppTheme",
        ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class QrListActivity : AppCompatActivity
    {
        TextView codeText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_qr_list);
            codeText = FindViewById<TextView>(Resource.Id.codeText);
            showList();
        }

        private void showList()
        {
            var codeList = DataManager.RealmInstance.All<CodeQr>().ToList();
            if (codeList == null || codeList.Count == 0)
            {
                codeText.Text = GetString(Resource.String.empty_code);               
            }
            else
            {
                setList(codeList);
            }
        }

        private void setList(List<CodeQr> codeList)
        {
            foreach (CodeQr aux in codeList)
            {
                codeText.Text = aux.Code;
            }
        }
    }
}
