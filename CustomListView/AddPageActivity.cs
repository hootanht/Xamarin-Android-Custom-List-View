using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CustomListView.Model;

namespace CustomListView
{
    [Activity(Label = "AddPageActivity", Theme = "@style/AppTheme")]
    public class AddPageActivity : AppCompatActivity
    {
        private EditText etFirstName, etLastName, etEmail;
        private Button btnSave;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.add_page);
            etFirstName = FindViewById<EditText>(Resource.Id.etFirstName);
            etLastName = FindViewById<EditText>(Resource.Id.etLastName);
            etEmail = FindViewById<EditText>(Resource.Id.etEmail);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (etFirstName.Text == "")
            {
                etFirstName.Error = "Enter Your Name";
                return;
            }
            if (etLastName.Text == "")
            {
                etLastName.Error = "Enter Your LastName";
                return;
            }
            if (etEmail.Text == "")
            {
                etEmail.Error = "Enter Your Email";
                return;
            }
            if (!etEmail.Text.Contains("@"))
            {
                etEmail.Error = "Please Enter Valid Email";
                return;
            }
            People people = new People()
            {
                FirstName = etFirstName.Text,
                LastName = etLastName.Text,
                Email = etEmail.Text
            };
            MainActivity.fakelist.Add(people);
            Toast.MakeText(this, "Added Complete", ToastLength.Long).Show();
            Finish();
        }
    }
}