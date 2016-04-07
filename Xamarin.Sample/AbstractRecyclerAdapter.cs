namespace Xamarin.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Android.Content;
    using Android.Support.V7.Widget;
    using Android.Views;

    public abstract class AbstractRecyclerAdapter<TModel, TViewHolder> : RecyclerView.Adapter
        where TModel : class
        where TViewHolder : AbstractViewHolder
    {
        protected readonly Context Context;
        protected readonly List<TModel> Items;
        protected readonly int ResourceId;

        protected AbstractRecyclerAdapter(IEnumerable<TModel> items, int resourceId)
        {
            Items = items.ToList();
            ResourceId = resourceId;
        }

        protected AbstractRecyclerAdapter(Context context, IEnumerable<TModel> items, int resourceId)
            : this(items, resourceId)
        {
            Context = context;
        }

        public override int ItemCount
        {
            get { return Items.Count; }
        }

        public Action<View, TModel> OnItemClick { get; set; }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(ResourceId, parent, false);

            var viewHolder = Activator.CreateInstance(typeof (TViewHolder), view) as TViewHolder;
            viewHolder.OnItemClick += HandleItemClick;

            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var casted = holder as TViewHolder;

            OnBindRecyclerViewHolder(casted, position);
        }

        public void HandleItemClick(View view, int position)
        {
            if (OnItemClick == null)
                return;

            var model = Items[position];

            OnItemClick(view, model);
        }

        protected abstract void OnBindRecyclerViewHolder(TViewHolder viewHolder, int position);
    }
}