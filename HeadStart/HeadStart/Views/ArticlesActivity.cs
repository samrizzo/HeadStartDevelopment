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

namespace HeadStart.Views
{
    [Activity(Label = "ArticlesActivity")]
    public class ArticlesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            ActionBar.Hide();

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Articles);
        }
    }
}