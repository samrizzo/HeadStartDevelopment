using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
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
    [Activity(Label = "Home", Theme = "@style/MainTheme")]
    public class HomePageActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            // Get the layout container for each section
            var milestonesContainer = FindViewById<LinearLayout>(Resource.Id.MilestonesContainer);
            var warningsContainer = FindViewById<LinearLayout>(Resource.Id.WarningsContainer);
            var articlesContainer = FindViewById<LinearLayout>(Resource.Id.ArticlesContainer);

            // Get the toolbar and set it as a support actionbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // Get the bottom navigation
            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.BottomNavigation);

            // Add the navigation click events for the bottom navigation
            bottomNavigation.SelectedItemId = Resource.Id.HomeNavigation;
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

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

            if (item.ItemId == Android.Resource.Id.Home)
            {
                StartActivity(typeof(HomePageActivity));
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        void LoadFragment(int id)
        {
            if (id == Resource.Id.MilestonesNavigation)
            {
                StartActivity(typeof(MilestonesActivity));
            }

            else if (id == Resource.Id.WarningsNavigation)
            {
                StartActivity(typeof(WarningSignsActivity));
            }

            else if (id == Resource.Id.ArticlesNavigation)
            {
                StartActivity(typeof(ArticlesActivity));
            }
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
    }
}