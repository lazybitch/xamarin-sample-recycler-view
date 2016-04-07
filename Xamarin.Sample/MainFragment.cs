namespace Xamarin.Sample
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Support.V7.Widget;
    using Android.Views;

    public class MainFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Fragment_Main, container, false);
            var layoutManager = new LinearLayoutManager(Activity);

            var items = new[]
            {
                new SampleItem {Text = "First"},
                new SampleItem {Text = "Second"},
                new SampleItem {Text = "Third"}
            };

            var resourceId = Resource.Layout.Item_Main;
            var adapter = new SampleAdapter(Activity, items, resourceId);
            adapter.OnItemClick += HandleClick;

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);

            return view;
        }

        private void HandleClick(View view, SampleItem item)
        {
            var intent = new Intent(Activity, typeof (MainActivity));

            StartActivity(intent);
        }
    }
}