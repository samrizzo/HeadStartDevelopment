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
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using HeadStart.Views;

namespace HeadStart
{
    [Activity(Label = "HomePageActivity", Theme = "@style/Theme.AppCompat")]
    public class HomePageActivity : AppCompatActivity
    {
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

            // Get the containers for the bottom navigation
            

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
    }
}