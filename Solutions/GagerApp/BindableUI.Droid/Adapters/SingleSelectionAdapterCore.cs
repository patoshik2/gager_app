using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using AndroidX.RecyclerView.Widget;
using BindableUI.Droid.Views;
using Java.Lang;

namespace BindableUI.Droid.Adapters
{
    public abstract class SingleSelectionAdapterCore<T> : BindableRecyclerViewAdapterCore<T>,
        BindableRecyclerView.ISingleSelectionAdapter,
        RecyclerView.IRecyclerListener
    {
        #region Fields

        private readonly List<RecyclerView> _attachedRecyclerViews = new List<RecyclerView>();
        private T _selectedItem = default;
        private bool _showSelection;

        #endregion Fields

        #region Constructors/Finalizers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="showSelection"></param>
        public SingleSelectionAdapterCore(bool showSelection)
            : base()
        {
            ShowSelection = showSelection;

            AttachedToRecyclerView += OnRecyclerViewAttached;
            DetachedFromRecyclerView += OnRecyclerViewDetached;
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public object SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (!object.Equals(_selectedItem, value))
                {
                    if (_attachedRecyclerViews.Any())
                    {
                        int oldSelectedIndex = GetIndexOf(_selectedItem);
                        if (ShowSelection && oldSelectedIndex >= 0)
                        {
                            SetViewsSelectedState(_attachedRecyclerViews, oldSelectedIndex, false);
                        }
                    }

                    _selectedItem = (T)value;

                    if (_attachedRecyclerViews.Any())
                    {
                        int newSelectedIndex = GetIndexOf(_selectedItem);
                        if (ShowSelection && newSelectedIndex >= 0)
                        {
                            SetViewsSelectedState(_attachedRecyclerViews, newSelectedIndex, true);
                        }
                    }
                    OnSelectedItemChanged();
                    //TODO: Consider using INPC to track selected item changes
                }
            }
        }

        protected abstract int GetIndexOf(T item);

        protected virtual bool ShowSelection
        {
            get => _showSelection;
            set
            {
                _showSelection = value;
                OnShowSelectionChanged();
            }
        }

        #endregion Properties/Indexers

        #region Methods/Events

        protected override void OnItemClicked(int itemIndex, T item)
        {
            SelectItem(item);
        }

        private void OnShowSelectionChanged()
        {
            //TODO: Consider if NotifyItemChanged() is faster
            if (_attachedRecyclerViews.Any())
            {
                int selectedIndex = GetIndexOf((T)SelectedItem);
                if (selectedIndex >= 0)
                {
                    SetViewsSelectedState(_attachedRecyclerViews, selectedIndex, ShowSelection);
                }
            }
        }

        public event EventHandler SelectedItemChanged;

        private void OnRecyclerViewAttached(object sender, RecyclerAttachEventArgs e)
        {
            if (!_attachedRecyclerViews.Contains(e.RecyclerView))
            {
                _attachedRecyclerViews.Add(e.RecyclerView);
            }
        }

        private void OnRecyclerViewDetached(object sender, RecyclerAttachEventArgs e)
        {
            _attachedRecyclerViews.Remove(e.RecyclerView);
        }

        protected override void OnViewHolderBound(BindableViewHolder<T> holder)
        {
            //No action necessary
        }

        public sealed override void OnViewAttachedToWindow(Java.Lang.Object holder)
        {
            base.OnViewAttachedToWindow(holder);
            var bindableHolder = holder as BindableViewHolder<T>;
            if (bindableHolder == null)
            {
                //TODO: consider throwing an exception
                return;
            }
            //Set selected state
            bindableHolder.ItemView.Selected = bindableHolder.DataContext != null && bindableHolder.DataContext.Equals(_selectedItem) && ShowSelection;
            OnViewHolderAttachedToWindow(bindableHolder);
        }

        public sealed override void OnViewDetachedFromWindow(Java.Lang.Object holder)
        {
            base.OnViewDetachedFromWindow(holder);
            var bindableHolder = holder as BindableViewHolder<T>;
            if (bindableHolder == null)
            {
                //TODO: consider throwing an exception
                return;
            }
            OnViewHolderDetachedFromWindow(bindableHolder);
        }

        protected virtual void OnViewHolderDetachedFromWindow(BindableViewHolder<T> bindableHolder)
        {
        }

        protected virtual void OnViewHolderAttachedToWindow(BindableViewHolder<T> bindableHolder)
        {
        }

        protected override void OnViewHolderUnbound(BindableViewHolder<T> holder)
        {
            // No action necessary
        }

        private void OnSelectedItemChanged()
        {
            EventHandler handler = SelectedItemChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void SelectItem(object obj)
        {
            SelectedItem = obj;
        }

        private void SetViewsSelectedState(IEnumerable<RecyclerView> attachedRecyclerViews, int index, bool selected)
        {
            foreach (RecyclerView recyclerView in attachedRecyclerViews)
            {
                RecyclerView.ViewHolder holder = recyclerView.FindViewHolderForAdapterPosition(index);
                //Set selected state
                if (holder != null && holder.ItemView != null)
                {
                    holder.ItemView.Selected = selected;
                }
            }
        }

        #endregion Methods/Events
    }
}
