using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;


namespace DoConnectMobi
{
    /// <summary>
    /// Main Activity
    /// </summary>
    /// <seealso cref="Android.App.Activity" />
    [Activity(Label = "Login", MainLauncher = true, Icon = "@drawable/icon")]
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
            TextView registerLink = FindViewById<TextView>(Resource.Id.link_register);


            List<string> tt = new List<string>();
            login.Click += (object sender, EventArgs e) => {
                //DataClient.DataLayer dl = new DataClient.DataLayer();
                //bool status = dl.Login(txtUsername.Text, txtPassword.Text);
                Validation valid = new Validation();
                bool val = valid.isValidEmail(txtUsername.Text);
                if (val)
                {
                    if (true)
                    {
                        var welcomeIntent = new Intent(this, typeof(WelcomeActivity));
                        welcomeIntent.PutStringArrayListExtra("userName", tt);
                        StartActivity(typeof(WelcomeActivity));
                    }
                    else
                        Toast.MakeText(this, "Unsuccessful Logg in", ToastLength.Long).Show();
                }
            };

            registerLink.Click += delegate
            {
                var signUpIntent = new Intent(this, typeof(SignUpActivity));
                StartActivity(signUpIntent);
            };
        }
    }
}

