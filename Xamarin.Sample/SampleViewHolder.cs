namespace Xamarin.Sample
{
    using Android.Views;
    using Android.Widget;

    public class SampleViewHolder : AbstractViewHolder
    {
        private readonly TextView txt;

        public SampleViewHolder(View view)
            : base(view)
        {
            txt = view.FindViewById<TextView>(Resource.Id.item_text);
        }

        public string Text
        {
            get { return txt.Text; }

            set { txt.Text = value; }
        }
    }
}