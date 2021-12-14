using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using frameworks.CSharp.Data.model;
using frameworks.CSharp.Utils;

namespace lectorQr.CSharp.Presentation.Adapter
{
    public class QrListAdapter : RecyclerView.Adapter
    {
        Android.App.Activity activity;
        List<CodeQr> listQrCode;

        public QrListAdapter(Android.App.Activity activity, List<CodeQr> listQrCode)
        {
            this.activity = activity;
            this.listQrCode = listQrCode;
        }

        public override int ItemCount
        {
            get
            {
                return listQrCode.Count;
            }
        }

        public class QrViewHolder : RecyclerView.ViewHolder
        {

            public View mView;
            public TextView titleText { get; private set; }

            public QrViewHolder(View view, Action<List<Object>> listener) : base(view)
            {
                titleText = view.FindViewById<TextView>(Resource.Id.titleText);
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            QrViewHolder qrViewHolder = holder as QrViewHolder;
            CodeQr code = listQrCode[position];
            qrViewHolder.titleText.Text = StringCipher.Decrypt(code.Code, Constants.KEY); 
           
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemQr = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_qr, parent, false);
            QrViewHolder qrViewholder = new QrViewHolder(itemQr, onClick);

            return qrViewholder;
        }

        private void onClick(List<Object> listObj)
        {

        }
    }
}
