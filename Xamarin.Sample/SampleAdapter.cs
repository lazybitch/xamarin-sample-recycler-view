namespace Xamarin.Sample
{
    using System.Collections.Generic;
    using Android.Content;

    public class SampleAdapter : AbstractRecyclerAdapter<SampleItem, SampleViewHolder>
    {
        public SampleAdapter(Context context, IEnumerable<SampleItem> items, int resourceId)
            : base(context, items, resourceId)
        {
        }

        protected override void OnBindRecyclerViewHolder(SampleViewHolder viewHolder, int position)
        {
            var item = Items[position];

            viewHolder.Text = item.Text;
        }
    }
}