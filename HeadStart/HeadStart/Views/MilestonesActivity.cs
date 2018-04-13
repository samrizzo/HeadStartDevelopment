using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using HeadStart.Views;

namespace HeadStart.Views
{
    [Activity(Label = "MilestonesActivity", Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class MilestonesActivity : AppCompatActivity
    {
        List<string> firstYearCategories;
        List<string> oneYearCategories;

        ListView firstYearListView;
        ListView yearOneListView;

        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Milestones);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.menu);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            firstYearCategories = new List<string>()
            {
                "0 - 3 Months",
                "3 - 6 Months",
                "6 - 9 Months",
                "9 - 12 Months"
            };

            oneYearCategories = new List<string>()
            {
                "12 - 18 Months",
                "18 - 24 Months"
            };

            // Add adapter for first year list view
            firstYearListView = FindViewById<ListView>(Resource.Id.FirstYearList);
            ArrayAdapter<string> firstYearAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, firstYearCategories);
            firstYearListView.Adapter = firstYearAdapter;

            // Add adapter for year one list view
            yearOneListView = FindViewById<ListView>(Resource.Id.YearOldList);
            ArrayAdapter<string> yearOneAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, oneYearCategories);
            yearOneListView.Adapter = yearOneAdapter;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}