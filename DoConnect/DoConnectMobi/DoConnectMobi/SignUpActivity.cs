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

namespace DoConnectMobi
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Android.App.Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignUp);

            EditText txtName = FindViewById<EditText>(Resource.Id.input_name);
            EditText txtSurname = FindViewById<EditText>(Resource.Id.input_surname);
            EditText txtIdNumber = FindViewById<EditText>(Resource.Id.input_idNumber);
            EditText txtDOB = FindViewById<EditText>(Resource.Id.input_DOB);
            RadioGroup rdbGroupGender = FindViewById<RadioGroup>(Resource.Id.GenderRadioGroup);
            RadioButton rdbGender = FindViewById<RadioButton>(rdbGroupGender.CheckedRadioButtonId);
            EditText txtPostalAddress = FindViewById<EditText>(Resource.Id.input_address);
            EditText txtEmail = FindViewById<EditText>(Resource.Id.input_email);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.input_password);
            EditText txtPasswordConfirm = FindViewById<EditText>(Resource.Id.input_passwordconfirm);
            Button btnSubmit = FindViewById<Button>(Resource.Id.btn_signup);

            btnSubmit.Click += (object sender, EventArgs e) => 
            {
                Validation valid = new Validation();
                bool validatEmail = valid.isValidEmail(txtEmail.Text);
                bool validatePassword = valid.isValidPassword(txtPassword.Text, txtPasswordConfirm.Text);
            };
        }
    }
}