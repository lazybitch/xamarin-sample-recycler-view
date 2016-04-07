namespace Xamarin.Sample
{
    using System;
    using Android.Support.V7.Widget;
    using Android.Views;

    public class AbstractViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        protected AbstractViewHolder(View view)
            : base(view)
        {
            view.SetOnClickListener(this);
        }

        public Action<View, int> OnItemClick { get; set; }

        public void OnClick(View view)
        {
            OnItemClick?.Invoke(view, AdapterPosition);
        }
    }
}