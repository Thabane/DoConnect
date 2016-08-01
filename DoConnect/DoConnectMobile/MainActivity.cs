using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
//using DataCient;

namespace DoConnectMobile
{
    [Activity(Label = "DoConnectMobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button login = FindViewById<Button>(Resource.Id.login);
            EditText txtUsername = FindViewById<EditText>(Resource.Id.userName);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.password);
            
            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            login.Click += (object sender, EventArgs e) => {
                //Toast.MakeText(this, "Logged in", ToastLength.Short).Show();
                DataClient.DataLayer dl = new DataClient.DataLayer();
                bool status = dl.Login(txtUsername.Text, txtPassword.Text);
                if(status)
                    Toast.MakeText(this, "Logged in", ToastLength.Short).Show();
                else
                    Toast.MakeText(this, "Unsuccessful Logg in", ToastLength.Long).Show();
            };
        }
    }
}

