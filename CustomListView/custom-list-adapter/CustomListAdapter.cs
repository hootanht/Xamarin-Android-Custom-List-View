using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomListView.Model;

namespace CustomListView.custom_list_adapter
{
    class CustomListAdapter : BaseAdapter<People>
    {
        Context context;
        List<People> peoples;
        public CustomListAdapter(Context Context, List<People> List)
        {
            context = Context;
            peoples = List;
        }
        public override People this[int position] => peoples[position];

        public override int Count => peoples.Count;

        public override long GetItemId(int position)
        {
            return peoples[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.custom_listview, null);
                view.FindViewById<TextView>(Resource.Id.txtFirstName).Text = peoples[position].FirstName;
                view.FindViewById<TextView>(Resource.Id.txtLastName).Text = peoples[position].LastName;
                view.FindViewById<TextView>(Resource.Id.txtEmail).Text = peoples[position].Email;
            }
            return view;
        }
    }
}