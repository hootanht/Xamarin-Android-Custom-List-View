using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

using CustomListView.custom_list_adapter;
using System.Collections.Generic;
using CustomListView.Model;
using Android.Views;

namespace CustomListView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ListView lstPeoples;
        private EditText etSearch;
        public static List<People> fakelist;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            lstPeoples = FindViewById<ListView>(Resource.Id.lstPeoples);
            etSearch = FindViewById<EditText>(Resource.Id.etSearch);
            etSearch.TextChanged += EtSearch_TextChanged;
            fakelist = new List<People>();
            People p1 = new People()
            {
                Id = 1,
                FirstName = "hootan",
                LastName = "hemmati",
                Email = "yahoo.com"
            };
            People p2 = new People()
            {
                Id = 2,
                FirstName = "saman",
                LastName = "j",
                Email = "yahoo.com"
            };
            People p3 = new People()
            {
                Id = 3,
                FirstName = "mahan",
                LastName = "m",
                Email = "yahoo.com"
            };
            fakelist.Add(p1);
            fakelist.Add(p2);
            fakelist.Add(p3);
            UpdateList();
        }

        private void EtSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (etSearch.Text != "")
            {
                List<People> lstSearch = new List<People>();
                foreach (var item in fakelist)
                {
                    if (item.FirstName.StartsWith(etSearch.Text))
                    {
                        lstSearch.Add(item);
                    }
                }
                CustomListAdapter adapter = new CustomListAdapter(this, lstSearch);
                lstPeoples.Adapter = adapter;
            }
            else
            {
                UpdateList();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.mymneu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        protected override void OnResume()
        {
            UpdateList();
            base.OnResume();
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_add)
            {
                StartActivity(typeof(AddPageActivity));
            }
            return base.OnOptionsItemSelected(item);
        }
        public void UpdateList()
        {
            CustomListAdapter adapter = new CustomListAdapter(this, fakelist);
            lstPeoples.Adapter = adapter;
        }
    }
}