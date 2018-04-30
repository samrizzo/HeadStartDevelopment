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
    [Activity(Label = "Milestone Checklist", Theme = "@style/MainTheme")]
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

            // Get the bottom navigation
            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.BottomNavigation);

            // Add the navigation click events for the bottom navigation
            bottomNavigation.SelectedItemId = Resource.Id.MilestonesNavigation;
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            List<string> firstYearCategories = new List<string>()
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

            firstYearListView.ItemClick += FirstYear_ItemClick;
            yearOneListView.ItemClick += YearOne_ItemClick;
        }

        void FirstYear_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Get our item from the list adapter
            if (firstYearListView.Count > 0)
            {
                var item = this.firstYearListView.GetItemAtPosition(e.Position);
                var milestoneDetailsActivity = new Intent(this, typeof(MilestoneDetailsActivity));

                // Pass the correct age group to the milestone details activity
                if (item.ToString() == "0 - 3 Months")
                {
                    milestoneDetailsActivity.PutExtra("AgeGroup", 3);
                }
                else if (item.ToString() == "3 - 6 Months")
                {
                    milestoneDetailsActivity.PutExtra("AgeGroup", 6);
                }
                else if (item.ToString() == "6 - 9 Months")
                {
                    milestoneDetailsActivity.PutExtra("AgeGroup", 9);
                }
                else if (item.ToString() == "9 - 12 Months")
                {
                    milestoneDetailsActivity.PutExtra("AgeGroup", 12);
                }

                StartActivity(milestoneDetailsActivity);
            }         
        }

        void YearOne_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (yearOneListView.Count > 0)
            {
                //Get our item from the list adapter
                var item = this.yearOneListView.GetItemAtPosition(e.Position);
                var milestoneDetailsActivity = new Intent(this, typeof(MilestoneDetailsActivity));

                // Pass the correct age group to the milestone details activity
                if (item.ToString() == "12 - 18 Months")
                {
                    milestoneDetailsActivity.PutExtra("AgeGroup", 18);
                }
                else if (item.ToString() == "18 - 24 Months")
                {
                    milestoneDetailsActivity.PutExtra("AgeGroup", 24);
                }

                StartActivity(milestoneDetailsActivity);
            }           
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