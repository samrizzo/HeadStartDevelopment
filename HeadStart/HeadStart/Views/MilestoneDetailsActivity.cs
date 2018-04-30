using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using HeadStart.Models;

namespace HeadStart.Views
{
    [Activity(Label = "Milestone Details", Theme ="@style/MainTheme")]
    public class MilestoneDetailsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MilestoneDetails);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // Get the bottom navigation
            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.BottomNavigation);

            // Add the navigation click events for the bottom navigation
            bottomNavigation.SelectedItemId = Resource.Id.MilestonesNavigation;
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            int ageGroup = Intent.GetIntExtra("AgeGroup", 0);

            if (ageGroup != 0)
            {
                // Create the database
                HeadStartDbContext db = new HeadStartDbContext();

                db.DatabaseStartup();

                List<string> milestoneData = db.GetMilestoneData(ageGroup);

                ListView milestoneDetailsListView = FindViewById<ListView>(Resource.Id.MilestoneDetailsList);
                ArrayAdapter<string> milestoneDetailsListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, milestoneData);
                milestoneDetailsListView.Adapter = milestoneDetailsListAdapter;
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (item.ItemId == Android.Resource.Id.Home)
            {
                StartActivity(typeof(MilestonesActivity));
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