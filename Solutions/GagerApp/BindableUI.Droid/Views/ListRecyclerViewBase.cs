using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.View;
using AndroidX.RecyclerView.Widget;
using BindableUI.Droid.Adapters;
using BindableUI.Droid.Utils;
using TomsToolbox.ObservableCollections;

namespace BindableUI.Droid.Views
{
    public abstract class ListRecyclerViewBase : FrameLayout
    {
        #region Fields

        private bool _allowReordering;
        private bool _clipToPadding = false;
        private int _dragHandleId;
        private ItemTouchHelper _helper;
        private ICommand _itemClickCommand;
        private IEnumerable _itemsSource;
        private BindableRecyclerView _recyclerView;
        private bool _showSelection;
        private object _storedSelectedItem;
        private IViewSelector _viewSelector;

        #endregion Fields

        #region Constructors

        public ListRecyclerViewBase(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize(context, attrs);
        }

        public ListRecyclerViewBase(Context context)
            : base(context)
        {
            Initialize(context, null);
        }

        public ListRecyclerViewBase(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            Initialize(context, attrs);
        }

        public ListRecyclerViewBase(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Initialize(context, attrs);
        }

        protected ListRecyclerViewBase(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The possibility of reordering depends on two things:
        /// <see cref="AllowReordering"/> is set to true and <see cref="IsReadOnly"/> == true
        /// </summary>
        public bool AllowReordering
        {
            get => _allowReordering;
            set
            {
                if (_allowReordering != value)
                {
                    _allowReordering = value;
                    UpdateItemTouchHelper();
                }
            }
        }

        /// <summary>
        /// Checks for <see cref="ItemsSource"/> is <see cref="IList"/> with <see cref="IList.IsReadOnly"/> == false
        /// </summary>
        public bool IsReadOnly => RecyclerViewAdapter == null ? true : RecyclerViewAdapter.IsReadOnly;

        /// <summary>
        /// An optinal value to have dedicated "drag handle" view at items' layout.
        /// If the value is not set, user can drag item by holding any point on it.
        /// </summary>
        public int DragHandleId
        {
            get => _dragHandleId;
            set
            {
                if (_dragHandleId != value)
                {
                    _dragHandleId = value;
                    OnDragHandleIdChanged();
                }
            }
        }

        public ICommand ItemClickCommand
        {
            get => _itemClickCommand;
            set
            {
                if (_itemClickCommand != value)
                {
                    _itemClickCommand = value;
                    OnItemClickCommandChanged();
                }
            }
        }

        public IEnumerable ItemsSource
        {
            get => _itemsSource;
            set
            {
                if (_itemsSource != value)
                {
                    _itemsSource = value;
                    OnItemsSourceChanged();
                }
            }
        }

        public override ViewGroup.LayoutParams LayoutParameters
        {
            get => base.LayoutParameters;
            set
            {
                if (value.Width == LayoutParams.WrapContent)
                {
                    _recyclerView.LayoutParameters.Width = LayoutParams.WrapContent;
                }
                else
                {
                    _recyclerView.LayoutParameters.Width = LayoutParams.MatchParent;
                }
                if (value.Height == LayoutParams.WrapContent)
                {
                    _recyclerView.LayoutParameters.Height = LayoutParams.WrapContent;
                }
                else
                {
                    _recyclerView.LayoutParameters.Height = LayoutParams.MatchParent;
                }

                base.LayoutParameters = value;
            }
        }

        public bool ScrollToInsertedItem
        {
            get;
            set;
        }
        public object SelectedItem
        {
            get => _storedSelectedItem;
            set
            {
                if (_storedSelectedItem != value)
                {
                    _storedSelectedItem = value;
                    if (RecyclerViewAdapter != null)
                    {
                        RecyclerViewAdapter.SelectedItem = value;
                    }
                    else
                    {
                        OnSelectedItemChanged();
                    }
                }
            }
        }

        /// <summary>
        /// ShowSelection would not work if <see cref="ItemClickCommand"/> is set.
        /// <para>
        /// Default is False.
        /// </para>
        /// </summary>
        public bool ShowSelection
        {
            get => _showSelection;
            set
            {
                if (_showSelection != value)
                {
                    _showSelection = value;
                    OnShowSelectionChanged();
                }
            }
        }

        public IViewSelector ViewSelector
        {
            get => _viewSelector;
            set
            {
                if (_viewSelector != value)
                {
                    _viewSelector = value;
                    OnViewSelectorChanged();
                }
            }
        }

        protected RecyclerView.ItemDecoration Decoration
        {
            get => _recyclerView.Decoration;
            set
            {
                if (value == null)
                {
                    if (_recyclerView.Decoration != null)
                    {
                        _recyclerView.RemoveItemDecoration(_recyclerView.Decoration);
                    }
                }
                else
                {
                    _recyclerView.Decoration = value;
                    //TODO: invalidate?
                    _recyclerView.InvalidateItemDecorations();
                }
            }
        }

        private BindableRecyclerViewAdapter RecyclerViewAdapter => _recyclerView.RecyclerAdapter as BindableRecyclerViewAdapter;

        #endregion Properties

        #region Methods

        public void RemoveItemAt(int itemIndex)
        {
            RecyclerViewAdapter.RemoveItemAt(itemIndex);
        }

        /// <summary>
        /// Tries to find item index for given view.
        /// <para>The <paramref name="view"/> may be a root item view, or a child of item view.</para>
        /// </summary>
        /// <param name="view"></param>
        /// <returns>-1 if the index was not found</returns>
        public int GetItemIndexForView(View view)
        {
            var holder = _recyclerView.FindContainingViewHolder(view);
            if (holder == null)
            {
                return -1;
            }
            return holder.AdapterPosition;
        }

        public event EventHandler SelectedItemChanged;

        public override void SetClipToPadding(bool clipToPadding)
        {
            base.SetClipToPadding(clipToPadding);
            _clipToPadding = clipToPadding;
            _recyclerView?.SetClipToPadding(_clipToPadding);
        }

        protected abstract RecyclerView.LayoutManager CreateLayoutManager(Context context, IAttributeSet attrs);

        protected abstract ItemTouchCallback.Direction GetAllowedDragDirection();

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            UpdateAdapter();
            UpdateItemTouchHelper();
        }

        protected override void OnDetachedFromWindow()
        {
            if (RecyclerViewAdapter != null)
            {
                RecyclerViewAdapter.SelectedItemChanged -= RecyclerViewAdapter_SelectedItemChanged;
            }
            _recyclerView.RecyclerAdapter = null;
            base.OnDetachedFromWindow();
        }

        protected abstract void OnInitializationComplete(Context context, IAttributeSet attrs);

        private void Initialize(Context context, IAttributeSet attrs)
        {
            if (_recyclerView != null)
            {
                //Means we've already initialized the view
                return;
            }

            _recyclerView = new BindableRecyclerView(Context)
            {
                LayoutParameters = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent),
                DropAdapterOnDetachFromWindow = false,
                NestedScrollingEnabled = true
            };
            //A "solution" to make _clipToPadding work
            //Disabled for now, 'coz it might cause problems
            //_recyclerView.SetPadding(PaddingLeft, PaddingTop, PaddingRight, PaddingBottom);
            //_recyclerView.SetClipToPadding(_clipToPadding);
            //base.SetPadding(0, 0, 0, 0);

            _recyclerView.RecyclerLayoutManager = CreateLayoutManager(context, attrs);

            //TODO: this should be moved to child class and allowed to be configured via xml.
            //Utils.RecyclerViewNestedScrollingManager.AttachNestedScrollingManager(_recyclerView);

            AddView(_recyclerView);

            ReadXmlAttributes(context, attrs);

            OnInitializationComplete(context, attrs);
        }

        private void OnDragHandleIdChanged()
        {
            if (RecyclerViewAdapter != null)
            {
                RecyclerViewAdapter.DragHandleViewId = DragHandleId;
            }
        }

        private void OnItemClickCommandChanged()
        {
            if (RecyclerViewAdapter != null)
            {
                RecyclerViewAdapter.ItemClickCommand = ItemClickCommand;
            }
        }

        private void OnItemsSourceChanged()
        {
            UpdateAdapter();
            UpdateItemTouchHelper();
        }

        private void OnSelectedItemChanged()
        {
            var h = SelectedItemChanged;
            h?.Invoke(this, EventArgs.Empty);
        }

        private void OnShowSelectionChanged()
        {
            if (RecyclerViewAdapter != null)
            {
                RecyclerViewAdapter.DisplaySelection = _showSelection;
            }
        }

        private void OnViewSelectorChanged()
        {
            UpdateAdapter();
        }

        private void ReadXmlAttributes(Context context, IAttributeSet attrs)
        {
            if (IsInEditMode)
            {
                return;
            }

            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.ListRecyclerViewBase);
            bool showSelection = false;
            bool allowReordering = false;
            int dragHandleId = -1;
            bool scrollToInsertedItem = false;
            if (typedArray != null)
            {
                showSelection = typedArray.GetBoolean(Resource.Styleable.ListRecyclerViewBase_showSelection, false);
                allowReordering = typedArray.GetBoolean(Resource.Styleable.ListRecyclerViewBase_allowReordering, false);
                dragHandleId = typedArray.GetResourceId(Resource.Styleable.ListRecyclerViewBase_reorderHandleId, -1);
                scrollToInsertedItem = typedArray.GetBoolean(Resource.Styleable.ListRecyclerViewBase_scrollToInsertedItem, false);

            }
            typedArray?.Recycle();

            ShowSelection = showSelection;
            AllowReordering = allowReordering;
            DragHandleId = dragHandleId;
            ScrollToInsertedItem = scrollToInsertedItem;
        }

        private void RecyclerViewAdapter_HolderDragStarted(object sender, ViewHolderEventArgs e)
        {
            _helper?.StartDrag(e.ViewHolder);
        }

        private void RecyclerViewAdapter_ItemsAdded(object sender, ItemsChangedEventArgs e)
        {
            if (ScrollToInsertedItem)
            {
                _recyclerView.ScrollToPosition(e.StartIndex + e.ItemsCount - 1);
            }
        }

        private void RecyclerViewAdapter_SelectedItemChanged(object sender, EventArgs e)
        {
            //Store selected item
            _storedSelectedItem = RecyclerViewAdapter.SelectedItem;
            OnSelectedItemChanged();
        }

        private void UpdateAdapter()
        {
            bool isAttachedToWindow = Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat
                ? IsAttachedToWindow
                : ViewCompat.IsAttachedToWindow(this);
            if (!isAttachedToWindow)
            {
                return;
            }            
            if (RecyclerViewAdapter != null)
            {
                RecyclerViewAdapter.SelectedItemChanged -= RecyclerViewAdapter_SelectedItemChanged;
                RecyclerViewAdapter.HolderDragStarted -= RecyclerViewAdapter_HolderDragStarted;
                RecyclerViewAdapter.ItemsAdded -= RecyclerViewAdapter_ItemsAdded;
            }
            //Creating and setting new adapter
            IList list = _itemsSource as IList;
            if (list == null)
            {
                if (_itemsSource != null)
                {
                    //This will cause source collection enumeration.
                    list = new ObservableWrappedCollection<object, object>(_itemsSource, (obj) => obj);
                }
            }
            if (ViewSelector != null && list != null)
            {
                var adapter = new BindableRecyclerViewAdapter(list, ViewSelector, false, GetAllowedDragDirection)
                {
                    ItemClickCommand = ItemClickCommand,
                    SelectedItem = _storedSelectedItem,
                    DisplaySelection = ShowSelection,
                    DragHandleViewId = DragHandleId,
                };
                adapter.SelectedItemChanged += RecyclerViewAdapter_SelectedItemChanged;
                adapter.HolderDragStarted += RecyclerViewAdapter_HolderDragStarted;
                adapter.ItemsAdded += RecyclerViewAdapter_ItemsAdded;
                _recyclerView.RecyclerAdapter = adapter;
            }
            else
            {
                //TODO: consider events unsubscribing
                _recyclerView.RecyclerAdapter = null;
                //TODO: consider dropping _storedSelectedItem
            }
        }

        private ItemTouchCallback.Direction GetAllowedDragDirection(RecyclerView recyclerView, RecyclerView.ViewHolder holder)
        {
            if (recyclerView != _recyclerView)
            {
                return ItemTouchCallback.Direction.None;
            }
            return GetAllowedDragDirection();
        }

        private void UpdateItemTouchHelper()
        {
            if (RecyclerViewAdapter == null)
            {
                return;
            }

            if (_helper != null)
            {
                //Detaching old helper, if any
                _helper.AttachToRecyclerView(null);
            }

            bool canReorder = !RecyclerViewAdapter.IsReadOnly;
            if (AllowReordering && canReorder)
            {
                _helper = new ItemTouchHelper(new ItemTouchCallback(RecyclerViewAdapter));
                _helper.AttachToRecyclerView(_recyclerView);
            }
        }

        #endregion Methods

        #region Classes

        /// <summary>
        /// TODO: Consider moving dragging part to <see cref="SingleSelectionAdapterBase"/> and use it as a parent
        /// </summary>
        private class BindableRecyclerViewAdapter : SingleSelectionAdapterCore<object>, IItemTouchCallbackManager
        {
            #region Fields

            private readonly List<RecyclerView> _attachedRecyclerViews = new List<RecyclerView>();
            private readonly IViewSelector _selector;
            private readonly Func<RecyclerView, RecyclerView.ViewHolder, ItemTouchCallback.Direction> _getDragDirections;
            private ICommand _clickCommand;
            private int _dragHandleViewId = -1;
            private int _dragItemCurrentPosition = -1;
            private int _dragItemInitialPosition = -1;
            private bool _itemDragging = false;

            #endregion Fields

            #region Constructors/Finalizers

            public BindableRecyclerViewAdapter(
                IList items,
                IViewSelector selector,
                bool showSelection,
                Func<RecyclerView, RecyclerView.ViewHolder, ItemTouchCallback.Direction> getDragDirections
                )
                : base(showSelection)
            {
                Items = items ?? throw new ArgumentNullException(nameof(items));
                _selector = selector ?? throw new ArgumentNullException(nameof(selector));
                _getDragDirections = getDragDirections ?? throw new ArgumentNullException(nameof(getDragDirections));
                AttachedToRecyclerView += OnRecyclerViewAttached;
                DetachedFromRecyclerView += OnRecyclerViewDetached;
            }

            #endregion Constructors/Finalizers

            #region Properties/Indexers

            bool IItemTouchCallbackManager.CanDragByLongPress => DragHandleViewId < 0;

            /// <summary>
            /// Has no efect if <see cref="ItemClickCommand"/> is set.
            /// </summary>
            public bool DisplaySelection
            {
                get => ShowSelection;
                set => ShowSelection = value;
            }

            public int DragHandleViewId
            {
                get => _dragHandleViewId;
                set
                {
                    if (_dragHandleViewId != value)
                    {
                        _dragHandleViewId = value;
                        //TODO: What about holders that are alresdy bound?                        
                    }
                }
            }

            public bool IsReadOnly => Items.IsReadOnly;

            public ICommand ItemClickCommand
            {
                get => _clickCommand;
                set
                {
                    if (_clickCommand != value)
                    {
                        _clickCommand = value;
                        //Reloading all views to re-bind data
                        //TODO: consider re-binding only visible views
                        RunOnUiThread(() => NotifyDataSetChanged());
                    }
                }
            }

            public sealed override int ItemCount => Items.Count;

            protected override bool ShowSelection
            {
                get => base.ShowSelection && _clickCommand == null;
                set => base.ShowSelection = value;
            }

            private IList Items
            {
                get;
            }

            #endregion Properties/Indexers

            #region Methods/Events

            public event EventHandler<ViewHolderEventArgs> HolderDragStarted;

            public event EventHandler<ItemsChangedEventArgs> ItemsAdded;

            ItemTouchCallback.Direction IItemTouchCallbackManager.GetAllowedDragDirections(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
            {
                return _getDragDirections(recyclerView, viewHolder);
            }

            void IItemTouchCallbackManager.OnItemDragMoved(RecyclerView recyclerView, int fromPosition, int toPosition)
            {
                if (IsReadOnly)
                {
                    //This shouldn't happen. Just don't do anything
                    return;
                }
                //TODO: check recyclerView?
                if (_dragItemInitialPosition == -1)
                {
                    _dragItemInitialPosition = fromPosition;
                }
                _dragItemCurrentPosition = toPosition;
                //Notify recyclerView, but don't actually move item
                NotifyItemMoved(fromPosition, toPosition);
            }

            void IItemTouchCallbackManager.OnItemDragStarted()
            {
                if (IsReadOnly)
                {
                    //This shouldn't happen. Just don't do anything
                    return;
                }
                _itemDragging = true;
                //Drop the initial position to invalid value to set it when actual position update happen
                _dragItemInitialPosition = -1;
            }

            void IItemTouchCallbackManager.OnItemDropped(RecyclerView recyclerView, int dropPosition)
            {
                if (IsReadOnly)
                {
                    //This shouldn't happen. Just don't do anything
                    return;
                }
                //TODO: check recyclerView?
                if (_dragItemInitialPosition == - 1)
                {
                    //There were no position change, no need to do anything
                }
                else
                {
                    //Move item in Items
                    var movedItem = Items[_dragItemInitialPosition];
                    Items.RemoveAt(_dragItemInitialPosition);
                    Items.Insert(dropPosition, movedItem);
                }
                _itemDragging = false;
            }

            protected sealed override int GetIndexOf(object item)
            {
                int index = Items.IndexOf(item);

                return AdjustIndexForDragging(index);
            }

            protected sealed override object GetItemAt(int position)
            {
                int index = AdjustIndexForDragging(position);
                return Items.ElementAtOrDefault(index);
            }

            protected sealed override int GetLayoutResourceIdFor(int position)
            {
                return _selector.GetLayoutResourceId(GetItemAt(position));
            }

            protected sealed override void OnItemClicked(int itemIndex, object item)
            {
                if (_clickCommand != null)
                {
                    if (_clickCommand.CanExecute(item))
                    {
                        _clickCommand.Execute(item);
                    }
                }
                else
                {
                    base.OnItemClicked(itemIndex, item);
                }
            }
            protected override void OnViewHolderBound(BindableViewHolder<object> holder)
            {
                base.OnViewHolderBound(holder);
                if (DragHandleViewId > 0)
                {
                    var handle = holder.ItemView.FindViewById(DragHandleViewId);
                    if (handle != null)
                    {
                        handle.SetOnTouchListener(new DragHandleTouchListener(holder, this));
                    }
                }
            }

            protected override void OnViewHolderUnbound(BindableViewHolder<object> holder)
            {
                base.OnViewHolderUnbound(holder);
                if (DragHandleViewId > 0)
                {
                    var handle = holder.ItemView.FindViewById(DragHandleViewId);
                    if (handle != null)
                    {
                        handle.SetOnTouchListener(null);
                    }
                }
            }

            private int AdjustIndexForDragging(int index)
            {
                if (_itemDragging)
                {
                    //correcting item index according to where item had been dragged
                    if (index > _dragItemInitialPosition && index <= _dragItemCurrentPosition)
                    {
                        return index--;
                    }
                    else if (index < _dragItemInitialPosition && index >= _dragItemCurrentPosition)
                    {
                        return index++;
                    }
                    else if (index == _dragItemInitialPosition)
                    {
                        return _dragItemCurrentPosition;
                    }
                }
                return index;
            }

            private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (_itemDragging)
                {
                    //All changes during dragging are already reflected
                    return;
                }
                //Since collection might be changed in any possible thread, we need to wrap notifications in View.Post methods
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        RunOnUiThread(
                            () =>
                            {
                                NotifyItemRangeInserted(e.NewStartingIndex, e.NewItems.Count);
                                OnItemsAdded(e.NewStartingIndex, e.NewItems.Count);
                            }
                            );
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        RunOnUiThread(() => NotifyItemRangeRemoved(e.OldStartingIndex, e.OldItems.Count));
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        for (int i = 0; i < e.OldItems.Count; i++)
                        {
                            RunOnUiThread(() => NotifyItemChanged(e.OldStartingIndex + i));
                        }
                        break;
                    //TODO: try to use NotifyItemMoved
                    case NotifyCollectionChangedAction.Move:
                        RunOnUiThread(() =>
                        {
                            NotifyItemRangeRemoved(e.OldStartingIndex, e.OldItems.Count);
                            NotifyItemRangeInserted(e.NewStartingIndex, e.NewItems.Count);
                        });
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        RunOnUiThread(() => NotifyDataSetChanged());
                        break;
                    default:
                        break;
                }
            }

            private void OnDragByHandleStarted(BindableViewHolder<object> holder)
            {
                var h = HolderDragStarted;
                h?.Invoke(this, new ViewHolderEventArgs(holder));
            }

            private void OnItemsAdded(int atIndex, int itemsCount)
            {
                var h = ItemsAdded;
                h?.Invoke(this, new ItemsChangedEventArgs(atIndex, itemsCount));
            }

            private void OnRecyclerViewAttached(object sender, RecyclerAttachEventArgs e)
            {
                if (_attachedRecyclerViews.Count == 0)
                {
                    //Subscribe for _cardTypes renewal and visual presentation tracking
                    INotifyCollectionChanged observableCollection = Items as INotifyCollectionChanged;
                    if (observableCollection != null)
                    {
                        observableCollection.CollectionChanged += Items_CollectionChanged;
                    }
                }
                if (!_attachedRecyclerViews.Contains(e.RecyclerView))
                {
                    _attachedRecyclerViews.Add(e.RecyclerView);
                }
            }

            private void OnRecyclerViewDetached(object sender, RecyclerAttachEventArgs e)
            {
                _attachedRecyclerViews.Remove(e.RecyclerView);
                if (_attachedRecyclerViews.Count == 0)
                {
                    //Unsubscribing is vital - otherwise the adapter will stay in memory as long as the collection do (and we don't know how long is that)
                    INotifyCollectionChanged observableCollection = Items as INotifyCollectionChanged;
                    if (observableCollection != null)
                    {
                        observableCollection.CollectionChanged -= Items_CollectionChanged;
                    }
                }
            }

            internal void RemoveItemAt(int itemIndex)
            {
                if (IsReadOnly)
                {
                    //TODO: consider throwing an exception
                    return;
                }
                if (itemIndex >= Items.Count || itemIndex < 0)
                {
                    throw new IndexOutOfRangeException(nameof(itemIndex));
                }
                var removedItem = Items[itemIndex];
                Items.RemoveAt(itemIndex);
                //If items is not an INotifyCollectionChanged, need to notify manually
                if (!(Items is INotifyCollectionChanged))
                {
                    Items_CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removedItem, itemIndex));
                }
            }

            #endregion Methods/Events

            #region Classes/Interfaces

            private class DragHandleTouchListener : Java.Lang.Object, IOnTouchListener
            {
                #region Fields

                private readonly BindableRecyclerViewAdapter _bindableRecyclerViewAdapter;
                private readonly BindableViewHolder<object> _holder;

                #endregion Fields

                #region Constructors/Finalizers

                public DragHandleTouchListener(BindableViewHolder<object> holder, BindableRecyclerViewAdapter bindableRecyclerViewAdapter)
                {
                    _holder = holder;
                    _bindableRecyclerViewAdapter = bindableRecyclerViewAdapter;
                }

                #endregion Constructors/Finalizers

                #region Methods/Events

                public bool OnTouch(View v, MotionEvent e)
                {
                    if (e.ActionMasked == MotionEventActions.Down)
                    {
                        _bindableRecyclerViewAdapter.OnDragByHandleStarted(_holder);
                    }
                    return true;
                }

                #endregion Methods/Events
            }

            #endregion Classes/Interfaces
        }

        private class ItemsChangedEventArgs : EventArgs
        {
            #region Constructors/Finalizers

            public ItemsChangedEventArgs(int startIndex, int itemsCount)
            {
                StartIndex = startIndex;
                ItemsCount = itemsCount;
            }

            #endregion Constructors/Finalizers

            #region Properties/Indexers

            public int ItemsCount
            {
                get;
            }

            public int StartIndex
            {
                get;
            }

            #endregion Properties/Indexers
        }

        private class ViewHolderEventArgs : EventArgs
        {
            #region Constructors/Finalizers

            public ViewHolderEventArgs(RecyclerView.ViewHolder viewHolder)
            {
                ViewHolder = viewHolder;
            }

            #endregion Constructors/Finalizers

            #region Properties/Indexers

            public RecyclerView.ViewHolder ViewHolder
            {
                get;
            }

            #endregion Properties/Indexers
        }
        #endregion Classes
    }
}
