using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZAD.Model;

namespace ZAD
{
    class LocationListAdapter : RecyclerView.Adapter
    {
        private List<LocationDetails> locationList;

        public LocationListAdapter(List<LocationDetails> locationList)
        {
            this.locationList = locationList;
        }

        public override int ItemCount =>locationList.Count ;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ListLocationViewHolder listLocationViewHolder = holder as ListLocationViewHolder;
            listLocationViewHolder.BindData(locationList[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.parkingDetailsListLayout, parent, false);
            return new ListLocationViewHolder(v);
        }
    }
    class ListLocationViewHolder : RecyclerView.ViewHolder
    {
        private TextView _textViewDate;
        private TextView _textViewLocation;
        public ListLocationViewHolder(View itemView) : base(itemView)
        {
            _textViewDate = itemView.FindViewById<TextView>(Resource.Id.textViewDateTime);
            _textViewLocation = itemView.FindViewById<TextView>(Resource.Id.textViewLocation);
        }

        internal void BindData(LocationDetails locationList)
        {
            _textViewDate.Text = locationList.dateTime;
            _textViewLocation.Text = locationList.locationName;
        }
    }
}