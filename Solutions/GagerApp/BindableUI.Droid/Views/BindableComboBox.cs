using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Database;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Calcium.UI.Data;
using Java.Lang;
using TomsToolbox.ObservableCollections;

namespace BindableUI.Droid.Views
{
    [Register("bindableUI.droid.views.BindableComboBox")]
    public class BindableComboBox : FrameLayout, AdapterView.IOnItemClickListener, PopupWindow.IOnDismissListener
    {
        #region Fields

        private IEnumerable _itemsSource;
        private BindableListAdapter _listAdapter;
        private object _selectedItem;
        private View _selectedView;
        private ViewGroup _selectedViewContainer;
        private AndroidX.AppCompat.Widget.ListPopupWindow _dropDownWindow;
        private IComboboxViewSelector _viewSelector;

        #endregion Fields

        #region Constructors/Finalizers

        public BindableComboBox(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize(context, attrs);
        }

        public BindableComboBox(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize(context, attrs);
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

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

        public object SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnSelectedItemChanged();
                }
            }
        }

        public IComboboxViewSelector ViewSelector
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

        private BindableListAdapter ListAdapter
        {
            get => _listAdapter;
            set
            {
                if (_listAdapter != value)
                {
                    //Free bindings
                    _listAdapter?.ClearBindingCache();
                    //close popup if it's opened
                    _dropDownWindow?.Dismiss();
                    _listAdapter = value;
                }
            }
        }

        #endregion Properties/Indexers

        #region Methods/Events

        void PopupWindow.IOnDismissListener.OnDismiss()
        {
            //Free bindings
            ListAdapter?.ClearBindingCache();
            //Drop selected state
            Selected = false;
            //We don't need this anymore
            _dropDownWindow.SetOnDismissListener(null);
            _dropDownWindow = null;
        }

        void AdapterView.IOnItemClickListener.OnItemClick(AdapterView parent, View view, int position, long id)
        {
            SelectedItem = ListAdapter.GetRawItem(position);
            _dropDownWindow.Dismiss();
        }

        public event EventHandler SelectedItemChanged;
        public event EventHandler ExplicitBindingsEvent;

        private void Initialize(Context context, IAttributeSet attrs)
        {
            if (IsInEditMode)
            {
                return;
            }

            if (_selectedViewContainer != null)
            {
                //we've already initialized the view
            }

            int containerLayoutId = 0;
            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.BindableComboBox);
            if (typedArray != null)
            {
                containerLayoutId = typedArray.GetResourceId(Resource.Styleable.BindableComboBox_bindableComboBoxLayout, 0);
            }
            typedArray?.Recycle();

            if (containerLayoutId == 0)
            {
                //Create default container
                _selectedViewContainer = new FrameLayout(context);
                var frameLayoutParams = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                _selectedViewContainer.LayoutParameters = frameLayoutParams;
                AddView(_selectedViewContainer);
            }
            else
            {
                //Inflate container
                var containerLayout = LayoutInflater.FromContext(context).Inflate(containerLayoutId, this, true);
                _selectedViewContainer = FindViewById<ViewGroup>(Resource.Id.bindableComboBox_container);
            }

            GetChildAt(0).Click += OnClick;
        }

        protected override void OnDetachedFromWindow()
        {
            //The view is moved out. It's about to be destroyed
            base.OnDetachedFromWindow();
            ListAdapter?.ClearBindingCache();
        }

        private void OnClick(object sender, EventArgs e)
        {
            //TODO: consider locking
            _dropDownWindow = new AndroidX.AppCompat.Widget.ListPopupWindow(Context);
            _dropDownWindow.AnchorView = sender as View;

            _dropDownWindow.SetAdapter(ListAdapter);
            _dropDownWindow.SetOnItemClickListener(this);

            _dropDownWindow.Width = _dropDownWindow.AnchorView.Width;
            _dropDownWindow.SetDropDownGravity((int)GravityFlags.Start);

            //Adjusting width and position for pre-lollipop devices
            if ((int)Build.VERSION.SdkInt < (int)Android.OS.BuildVersionCodes.Lollipop)
            {
                var background = _dropDownWindow.Background;
                if (background != null)
                {
                    var paddingRect = new Rect();
                    var hasPadding = background.GetPadding(paddingRect);
                    if (hasPadding)
                    {
                        _dropDownWindow.Width += paddingRect.Left + paddingRect.Right;
                        //TODO: check offset on various densities and writing directions
                        _dropDownWindow.HorizontalOffset = 0 - paddingRect.Left;
                    }
                }
            }

            _dropDownWindow.Modal = true;
            _dropDownWindow.SetOnDismissListener(this);
            _dropDownWindow.Show();
            //Set selected state
            Selected = true;
            _dropDownWindow.ListView.SetRecyclerListener(ListAdapter);
            if (SelectedItem != null)
            {
                _dropDownWindow.SetSelection(ListAdapter.GetItemIndex(SelectedItem));
            }
        }

        private void OnItemsSourceChanged()
        {
            UpdateAdapter();
        }

        private void OnSelectedItemChanged()
        {
            UpdateSelectedItemView();

            //Raise an event
            var h = SelectedItemChanged;
            h?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateSelectedItemView()
        {
            if (_selectedViewContainer == null)
            {
                return;
            }

            _selectedViewContainer.RemoveAllViews();
            if (ListAdapter != null)
            {
                if (_selectedView != null)
                {
                    ListAdapter?.Unbind(_selectedView);
                }

                if (SelectedItem != null)
                {
                    int itemIndex = ListAdapter.GetItemIndex(SelectedItem);
                    if (itemIndex == -1)
                    {
                        //TODO: consider resetting SelectedItem
                        _selectedView = null;
                    }
                    else
                    {
                        _selectedView = ListAdapter.GetSelectedView(itemIndex, null, _selectedViewContainer);
                        _selectedViewContainer.AddView(_selectedView);
                    }
                }
            }
        }

        private void OnViewSelectorChanged()
        {
            UpdateAdapter();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            if (ListAdapter != null)
            {
                ListAdapter.ItemHeightPx = _selectedViewContainer == null ? MeasuredHeight : _selectedViewContainer.MeasuredHeight;
            }
        }

        private void UpdateAdapter()
        {
            //Creating and setting new adapter
            if (ViewSelector != null && _itemsSource != null)
            {
                IList wrappedList = _itemsSource is IList 
                    ? _itemsSource as IList 
                    : new ObservableWrappedCollection<object, object>(_itemsSource, (o) => o);
                ListAdapter = new BindableListAdapter(wrappedList, ViewSelector) { ItemHeightPx = _selectedViewContainer == null ? MeasuredHeight : _selectedViewContainer.MeasuredHeight };
            }
            else
            {
                ListAdapter = null;
            }
            UpdateSelectedItemView();
        }

        public void InvokeUpdateExplicitBindings()
        {
            var h = ExplicitBindingsEvent;
            h?.Invoke(this, EventArgs.Empty);
        }

        #endregion Methods/Events

        #region Classes/Interfaces

        private class BindableListAdapter : Java.Lang.Object, IListAdapter, AbsListView.IRecyclerListener
        {
            #region Fields

            private readonly Dictionary<View, XmlBindingApplicator> _bindingCache = new Dictionary<View, XmlBindingApplicator>();
            private readonly IList _items;
            private readonly IComboboxViewSelector _selector;

            #endregion Fields

            #region Constructors/Finalizers

            public BindableListAdapter(IList content, IComboboxViewSelector viewSelector)
            {
                _items = content;
                _selector = viewSelector;
            }

            #endregion Constructors/Finalizers

            #region Properties/Indexers

            public int Count => _items.Count;

            public bool HasStableIds => false;

            public bool IsEmpty => !_items.Cast<object>().Any();

            public int ViewTypeCount => _selector.ViewTypeCount;

            public int ItemHeightPx
            {
                get;
                set;
            } = 0;

            #endregion Properties/Indexers

            #region Methods/Events

            public bool AreAllItemsEnabled()
            {
                //TODO: Test what to return here
                return true;
            }

            public void ClearBindingCache()
            {
                foreach (var pair in _bindingCache)
                {
                    pair.Value.RemoveBindings();
                }
                _bindingCache.Clear();
            }

            public Java.Lang.Object GetItem(int position)
            {
                return GetRawItem(position) as Java.Lang.Object;
            }

            public long GetItemId(int position)
            {
                return position;
            }

            public int GetItemIndex(object item)
            {
                return _items.IndexOf(item);
            }

            public int GetItemViewType(int position)
            {
                return _selector.GetItemViewType(GetRawItem(position));
            }

            public object GetRawItem(int position)
            {
                return _items[position];
            }

            public View GetView(int position, View convertView, ViewGroup parent)
            {
                int resourceID = _selector.GetLayoutResourceId(GetRawItem(position));
                return GetView(position, convertView, parent, resourceID);
            }

            private View GetView(int position, View convertView, ViewGroup parent, int resourceID)
            {
                //Check convertView and reuse if possible
                View resultView;
                XmlBindingApplicator applicator;
                if (convertView == null || !_bindingCache.ContainsKey(convertView))
                {
                    resultView = LayoutInflater.FromContext(parent.Context).Inflate(resourceID, parent, false);
                    applicator = new XmlBindingApplicator();
                    _bindingCache.Add(resultView, applicator);
                }
                else
                {
                    //TODO: more checks for convertView?
                    resultView = convertView;
                    applicator = _bindingCache[resultView];
                    applicator.RemoveBindings();
                }

                applicator.ApplyBindings(resultView, GetRawItem(position), resourceID);
                resultView.SetMinimumHeight(ItemHeightPx);
                return resultView;
            }

            public bool IsEnabled(int position)
            {
                //TODO: Consider asking _selector
                return true;
            }

            public void RegisterDataSetObserver(DataSetObserver observer)
            {
                
            }

            public void UnregisterDataSetObserver(DataSetObserver observer)
            {
                
            }

            public void Unbind(View view)
            {
                if (_bindingCache.TryGetValue(view, out var applicator))
                {
                    applicator.RemoveBindings();
                    _bindingCache.Remove(view);
                } 
            }

            void AbsListView.IRecyclerListener.OnMovedToScrapHeap(View view)
            {
                //TODO: consider removing the view from cache in this case
                Unbind(view);
            }

            internal View GetSelectedView(int position, View convertView, ViewGroup parent)
            {
                int resourceID = _selector.GetSelectedItemLayoutResourceId(GetRawItem(position));
                return GetView(position, convertView, parent, resourceID);
            }

            #endregion Methods/Events
        }

        #endregion Classes/Interfaces
    }
}
