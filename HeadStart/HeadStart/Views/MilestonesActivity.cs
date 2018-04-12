using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HeadStart.Views;

namespace HeadStart.Views
{
    [Activity(Label = "MilestonesActivity")]
    public class MilestonesActivity : Activity
    {
        List<string> firstYearCategories;
        List<string> oneYearCategories;

        ListView firstYearListView;
        ListView yearOneListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            ActionBar.Hide();

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Milestones);

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
    }
}