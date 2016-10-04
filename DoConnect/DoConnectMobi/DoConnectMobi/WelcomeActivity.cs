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
using Android.Support.V4.Widget;

namespace DoConnectMobi
{
    [Activity(Label = "WelcomeActivity")]
    public class WelcomeActivity : ListActivity
    {
        DrawerLayout mDrawerLayout;
        List<string> menuItemsLeft = new List<string>();
        ArrayAdapter mLeftAdapter;
        ListView mLeftDrawer;
        ArrayAdapter aAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Generics);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawer);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.leftListView);

            menuItemsLeft.Add("Appointments");
            menuItemsLeft.Add("2nd");
            menuItemsLeft.Add("3rd");

            mLeftAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, menuItemsLeft);
            mLeftDrawer.Adapter = mLeftAdapter;
        }
    }
}