using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    [Activity(Label = "Warning Signs", Theme = "@style/MainTheme")]
    public class WarningSignsActivity : AppCompatActivity
    {
        List<string> warningSigns;
        ListView warningSignsList;

        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WarningSigns);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // Get the bottom navigation
            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.BottomNavigation);

            // Add the navigation click events for the bottom navigation
            bottomNavigation.SelectedItemId = Resource.Id.WarningsNavigation;
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            warningSigns = new List<string>()
            {
                "By 3 or 4 months, doesn't grasp or reach for toys",
                "By 3 or 4 months, can't support his head well",
                "By 4 months, isn't bringing onjects to his mouth",
                "At 4 months, doesn't coo or start to babble",
                "By 6 months, can't sit with help",
                "By 5 or 6 months, doesn't roll over in either direction (back to front or front to back",
                "At 7 months, is not reaching for objects",
                "At 7 months, doesn't imitate sounds other people make",
                "By 7 months, doesn't bear some weight on his legs",
                "By 9 months, can't sit independently",
                "At 9 months, doesn't respond to her name",
                "At 9 months, doesn't look where you point",
                "After 10 months, crawls in a lopsided manner, pushing off with one hand and leg while dragging the opposite hand and leg",
                "At 12 months, is not crawling",
                "At 12 months, can't stand with support",
                "At 12 months, doesn't say 'mama' or 'dada'",
                "At 12 months, doesn't use gestures such as waving, shaking her head, or pointing",
                "At 12 months, isn't pointing out things of interest such as a bird or airplane overhead",
                "After several months of walking, doesn't walk confidently or consistently walks on toes",
                ""
            };


            // Add adapter for warning signs list view
            warningSignsList = FindViewById<ListView>(Resource.Id.WarningSignsList);
            ArrayAdapter<string> warningSignsAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, warningSigns);
            warningSignsList.Adapter = warningSignsAdapter;
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