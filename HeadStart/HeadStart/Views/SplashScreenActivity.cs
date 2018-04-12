using System.Threading.Tasks;
using Android.App;
using Android.OS;
using HeadStart.Views;

namespace HeadStart.Views
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true)]
    public class SplashScreenActivity : Activity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistantState)
        {
            base.OnCreate(savedInstanceState, persistantState);
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            StartActivity(typeof(HomePageActivity));
        }
    }
}