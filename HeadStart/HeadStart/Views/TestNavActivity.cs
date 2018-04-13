using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace HeadStart.Views
{
    [Activity(Label = "TestNavActivity", Theme ="@style/Theme.AppCompat.NoActionBar")]
    public class TestNavActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TestNav);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //Enable support action bar to display hamburger
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
            };
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