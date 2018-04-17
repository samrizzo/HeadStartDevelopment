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

namespace HeadStart.Views
{
    [Activity(Label = "Helpful Tips", Theme = "@style/MainTheme")]
    public class ArticlesActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Articles);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // Get the bottom navigation
            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.BottomNavigation);

            // Add the navigation click events for the bottom navigation
            bottomNavigation.SelectedItemId = Resource.Id.ArticlesNavigation;
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (item.ItemId == Android.Resource.Id.Home)
            {
                StartActivity(typeof(HomePageActivity));
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        void LoadFragment(int id)
        {
            if (id == Resource.Id.HomeNavigation)
            {
                StartActivity(typeof(HomePageActivity));
            }

            else if (id == Resource.Id.MilestonesNavigation)
            {
                StartActivity(typeof(MilestonesActivity));
            }

            else if (id == Resource.Id.WarningsNavigation)
            {
                StartActivity(typeof(WarningSignsActivity));
            }
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
    }
}