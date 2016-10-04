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
    [Activity(Label = "AppointmentsActivity")]
    public class AppointmentsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Appointments);
            // Create your application here
            CalendarView date = FindViewById<CalendarView>(Resource.Id.cvDate);
            TimePicker time = FindViewById<TimePicker>(Resource.Id.tpTime);
            Button btnApp = FindViewById<Button>(Resource.Id.btn_bookAppointment);

            long dt = date.Date;
            DateTime tt = new DateTime(dt);

            btnApp.Click += (object sender, EventArgs e) =>
            {

            };
        }
    }
}