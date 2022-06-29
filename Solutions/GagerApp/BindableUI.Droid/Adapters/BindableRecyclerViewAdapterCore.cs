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
using System.Windows.Input;
using Java.Lang;
using AndroidX.RecyclerView.Widget;

namespace BindableUI.Droid.Adapters
{
    public abstract class BindableRecyclerViewAdapterCore<T> : RecyclerView.Adapter,
        RecyclerView.IRecyclerListener
    {
        #region Properties/Indexers

        #endregion Properties/Indexers

        #region Methods/Events

        /// <summary>
        /// An action to be run when the item view is being clicked.
        /// </summary>
        /// <param name="itemIndex">Index of clicked item (not the view index)</param>
        /// <param name="item">Clicked item.</param>
        protected abstract void OnItemClicked(int itemIndex, T item);

        /// <summary>
        /// Raised when RecyclerView starts observing this Adapter.
        /// </summary>
        public event EventHandler<RecyclerAttachEventArgs> AttachedToRecyclerView;

        /// <summary>
        /// Raised when RecyclerView stops observing this Adapter.
        /// </summary>
        public event EventHandler<RecyclerAttachEventArgs> DetachedFromRecyclerView;

        public sealed override int GetItemViewType(int position)
        {
            return GetLayoutResourceIdFor(position);
        }

        public sealed override void OnAttachedToRecyclerView(RecyclerView recyclerView)
        {
            recyclerView.SetRecyclerListener(this);
            var h = AttachedToRecyclerView;
            h?.Invoke(this, new RecyclerAttachEventArgs(recyclerView));
        }

        public sealed override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            (holder as BindableViewHolder<T>).Bind(GetItemAt(position), OnItemClicked);
            OnViewHolderBound(holder as BindableViewHolder<T>);
        }

        public sealed override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position, IList<Java.Lang.Object> payloads)
        {
            //TODO: investigate what to do here
            base.OnBindViewHolder(holder, position, payloads);
        }

        public sealed override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            BindableViewHolder<T> cardViewHolder = new BindableViewHolder<T>(viewType, parent);
            return cardViewHolder;
        }

        public sealed override void OnDetachedFromRecyclerView(RecyclerView recyclerView)
        {
            recyclerView.SetRecyclerListener(null);
            var h = DetachedFromRecyclerView;
            h?.Invoke(this, new RecyclerAttachEventArgs(recyclerView));
        }

        void RecyclerView.IRecyclerListener.OnViewRecycled(RecyclerView.ViewHolder holder)
        {
            OnViewHolderUnbound(holder as BindableViewHolder<T>);
            (holder as BindableViewHolder<T>).Unbind();
        }

        /// <summary>
        /// Should return item to use as DataContext for <see cref="GetLayoutResourceIdFor(int)"/>.
        /// <para>
        /// Should not be null.
        /// </para>
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        protected abstract T GetItemAt(int position);

        /// <summary>
        /// A layout Resource to be inflated for item at <paramref name="position"/>.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        protected abstract int GetLayoutResourceIdFor(int position);

        /// <summary>
        /// Occurs after bindings has been applied to ViewHolder.ItemView
        /// </summary>
        /// <param name="holder"></param>
        protected abstract void OnViewHolderBound(BindableViewHolder<T> holder);

        /// <summary>
        /// Occurs after bindings has been removed from ViewHolder.ItemView
        /// </summary>
        /// <param name="holder"></param>
        protected abstract void OnViewHolderUnbound(BindableViewHolder<T> holder);

        protected void RunOnUiThread(Action action)
        {
            //If we're in UI thread (Main Looper), we do not use View.Post
            if (Looper.MainLooper.Equals(Looper.MyLooper()))
            {
                action.Invoke();
            }
            else
            {
                Handler handler = new Handler(Looper.MainLooper);
                handler.Post(action);
            }
        }

        #endregion Methods/Events

        public class RecyclerAttachEventArgs : EventArgs
        {
            public RecyclerAttachEventArgs(RecyclerView recyclerView)
            {
                RecyclerView = recyclerView;
            }

            public RecyclerView RecyclerView
            {
                get;
            }
        }
    }
}
