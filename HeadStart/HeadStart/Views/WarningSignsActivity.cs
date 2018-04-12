using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HeadStart.Views
{
    [Activity(Label = "WarningSignsActivity")]
    public class WarningSignsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            ActionBar.Hide();

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.WarningSigns);
        }
    }
}