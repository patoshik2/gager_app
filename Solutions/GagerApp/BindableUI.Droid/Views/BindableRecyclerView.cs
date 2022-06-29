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
using Android.Util;
using Android.Animation;
using AndroidX.RecyclerView.Widget;

namespace BindableUI.Droid.Views
{
    /// <summary>
    /// A recycler view with properties to support binding from XML
    /// Also have a simple implementation of SelectedItem tracking.
    /// And a simple implementation of ItemDecoration property.
    /// </summary>
    [Register("bindableUI.droid.views.BindableRecyclerView")]
    public class BindableRecyclerView : RecyclerView
    {
        #region Fields

        private static int InSystem_java = 0;
        private static int InSystem_net = 0;

        private bool _initialized = false;
        private ItemDecoration _itemDecoration;

        #endregion

        #region Properties/Indexers

        public ItemDecoration Decoration
        {
            get => _itemDecoration;
            set
            {
                if (_itemDecoration != value)
                {
                    RemoveItemDecoration(_itemDecoration);
                    _itemDecoration = value;
                    AddItemDecoration(_itemDecoration);
                    InvalidateItemDecorations();
                }
            }
        }

        /// <summary>
        /// If true, adapter will be set to null on this recyclerview detached from window.
        /// Default is true.
        /// </summary>
        public bool DropAdapterOnDetachFromWindow
        {
            get;
            set;
        } = true;

        /// <summary>
        /// If true, changing <see cref="View.Selected"/> state to this view will automatically propagate this state to child views.
        /// Default is false
        /// </summary>
        public bool PassSelectedStateToChildren
        {
            get;
            set;
        } = false;

        public RecyclerView.Adapter RecyclerAdapter
        {
            get => GetAdapter();
            set => SetAdapter(value);
        }

        public LayoutManager RecyclerLayoutManager
        {
            get => GetLayoutManager();
            set
            {
                if (GetLayoutManager() != value)
                {
                    SetLayoutManager(value);
                }
            }
        }
        /// <summary>
        /// Works only if the given adapter is <see cref="ISingleSelectionAdapter"/>
        /// </summary>
        public object SelectedItem
        {
            get
            {
                var selectionAdapter = RecyclerAdapter as ISingleSelectionAdapter;
                return selectionAdapter?.SelectedItem;
            }
            set
            {
                var selectionAdapter = RecyclerAdapter as ISingleSelectionAdapter;
                if (selectionAdapter != null)
                {
                    selectionAdapter.SelectedItem = value;
                }
            }
        }
        #endregion

        #region Methods/Events

        public override void DispatchSetSelected(bool selected)
        {
            if (PassSelectedStateToChildren)
            {
                base.DispatchSetSelected(selected);
            }
        }

        public event EventHandler SelectedItemChanged;

        public override void SetAdapter(Adapter adapter)
        {
            var oldAdapter = GetAdapter() as ISingleSelectionAdapter;
            if (oldAdapter != null)
            {
                oldAdapter.SelectedItemChanged -= Adapter_SelectedItemChanged;
            }
            base.SetAdapter(adapter);
            var newAdapter = GetAdapter() as ISingleSelectionAdapter;
            if (newAdapter != null)
            {
                newAdapter.SelectedItemChanged += Adapter_SelectedItemChanged;
            }
        }

        protected override void Dispose(bool disposing)
        {
#if DEBUG
            InSystem_net--;
            System.Diagnostics.Debug.WriteLine($"BindableRecyclerView Disposed. Total count: java={InSystem_java}, net={InSystem_net}");
#endif
            base.Dispose(disposing);
        }

        protected override void JavaFinalize()
        {
#if DEBUG
            InSystem_java--;
            System.Diagnostics.Debug.WriteLine($"BindableRecyclerView JavaFinalized. Total count: java={InSystem_java}, net={InSystem_net}");
#endif

            base.JavaFinalize();
        }

        protected override void OnDetachedFromWindow()
        {
            //Adapter needs to be reset to remove all bindings in it and free the ViewModel
            if (DropAdapterOnDetachFromWindow)
            {
                RecyclerAdapter = null;
            }
            base.OnDetachedFromWindow();
        }

        private void Adapter_SelectedItemChanged(object sender, EventArgs e)
        {
            OnSelectedItemChanged();
        }

        private void Initialize()
        {
            if (_initialized)
            {
                return;
            }

#if DEBUG
            InSystem_java++;
            InSystem_net++;
            System.Diagnostics.Debug.WriteLine($"BindableRecyclerView created. Total count: java={InSystem_java}, net={InSystem_net}");
#endif

            _initialized = true;
        }

        private void OnSelectedItemChanged()
        {
            var handler = SelectedItemChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Constructors/Finalizers

        public BindableRecyclerView(Context context) : base(context)
        {
            Initialize();
        }

        public BindableRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        public BindableRecyclerView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize();
        }

        protected BindableRecyclerView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Initialize();
        }

        #endregion

        #region Classes/Interfaces

        public interface ISingleSelectionAdapter
        {
            #region Properties/Indexers

            object SelectedItem
            {
                get; set;
            }

            #endregion Properties/Indexers

            #region Methods/Events

            event EventHandler SelectedItemChanged;

            #endregion Methods/Events
        }

        #endregion Classes/Interfaces

    }
}
