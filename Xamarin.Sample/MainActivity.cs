namespace Xamarin.Sample
{
    using Android.App;
    using Android.OS;

    [Activity(Label = "Xamarin.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            InitializeContentFragment();
        }

        private void InitializeContentFragment()
        {
            var fragment = new MainFragment();

            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.frame_main, fragment)
                .Commit();
        }
    }
}