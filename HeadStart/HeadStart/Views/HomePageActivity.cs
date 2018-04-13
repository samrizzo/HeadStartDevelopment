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

namespace HeadStart
{
    [Activity(Label = "HomePageActivity", Theme = "@style/MainTheme")]
    public class HomePageActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);

            // Get the layout container for each section
            var milestonesContainer = FindViewById<LinearLayout>(Resource.Id.MilestonesContainer);
            var warningsContainer = FindViewById<LinearLayout>(Resource.Id.WarningsContainer);
            var articlesContainer = FindViewById<LinearLayout>(Resource.Id.ArticlesContainer);

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


            // Add the navigation click events for the containers
            milestonesContainer.Click += delegate
            {
                StartActivity(typeof(MilestonesActivity));
            };

            warningsContainer.Click += delegate
            {
                StartActivity(typeof(WarningSignsActivity));
            };

            articlesContainer.Click += delegate
            {
                StartActivity(typeof(ArticlesActivity));
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