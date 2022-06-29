using System;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using AndroidX.RecyclerView.Widget;
using BindableUI.Droid.Utils;

namespace BindableUI.Droid.Views
{
    /// <summary>
    /// A "RecyclerView" that imitates a ListView from UWP
    /// </summary>
    [Register("bindableUI.droid.views.ListRecyclerView")]
    public class ListRecyclerView : ListRecyclerViewBase
    {
        #region Fields

        private CustomLinearLayoutManager _layoutManager;
        private Direction _orientation = Direction.Vertical;
        private bool _showDivider;

        #endregion Fields

        #region Constructors

        public ListRecyclerView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
        }

        public ListRecyclerView(Context context)
            : base(context)
        {
        }

        public ListRecyclerView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }

        public ListRecyclerView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected ListRecyclerView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion Constructors

        #region Properties

        public Direction ScrollDirection
        {
            get => _orientation;
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    OnScrollDirectionChanged();
                }
            }
        }

        public bool ShowDivider
        {
            get => _showDivider;
            set
            {
                if (_showDivider != value)
                {
                    _showDivider = value;
                    OnShowDividerChanged();
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// A duct-tape for current appbar menu implementation
        /// </summary>
        internal void LockScrolling()
        {
            _layoutManager.ScrollingEnabled = false;
        }

        /// <summary>
        /// A duct-tape for current appbar menu implementation
        /// </summary>
        internal void UnlockScrolling()
        {
            _layoutManager.ScrollingEnabled = true;
        }

        protected override RecyclerView.LayoutManager CreateLayoutManager(Context context, IAttributeSet attrs)
        {
            _layoutManager = new CustomLinearLayoutManager(context, LinearLayoutManager.Vertical, false)
            {
                RecycleChildrenOnDetach = true
            };
            return _layoutManager;
        }

        protected sealed override ItemTouchCallback.Direction GetAllowedDragDirection()
        {
            switch (_layoutManager.Orientation)
            {
                case LinearLayoutManager.Vertical:
                    return ItemTouchCallback.Direction.Up | ItemTouchCallback.Direction.Down;
                case LinearLayoutManager.Horizontal:
                    return ItemTouchCallback.Direction.Left | ItemTouchCallback.Direction.Right;                    
                default:
                    return ItemTouchCallback.Direction.None;
            }
        }

        protected override void OnInitializationComplete(Context context, IAttributeSet attrs)
        {
            ReadXmlAttributes(context, attrs);
        }

        private RecyclerView.ItemDecoration CreateItemDecoration(Context context)
        {
            return new DividerItemDecoration(context, _layoutManager.Orientation);
        }

        private void OnScrollDirectionChanged()
        {
            int orientation = ScrollDirection == Direction.Vertical ? LinearLayoutManager.Vertical : LinearLayoutManager.Horizontal;
            _layoutManager.Orientation = orientation;
            //TODO: do we need to invoke additional methods?
        }

        private void OnShowDividerChanged()
        {
            if (ShowDivider)
            {
                Decoration = CreateItemDecoration(Context);
            }
            else
            {
                Decoration = null;
            }
        }

        private void ReadXmlAttributes(Context context, IAttributeSet attrs)
        {
            if (IsInEditMode)
            {
                return;
            }

            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.ListRecyclerView);
            bool showDivider = true;
            int scrollDirection = (int)Direction.Vertical;

            if (typedArray != null)
            {
                showDivider = typedArray.GetBoolean(Resource.Styleable.ListRecyclerView_showDivider, true);
                scrollDirection = typedArray.GetInt(Resource.Styleable.ListRecyclerView_scrollDirection, 0);
            }
            typedArray?.Recycle();

            ScrollDirection = (Direction)scrollDirection;
            ShowDivider = showDivider;
        }

        #endregion Methods

        #region Enums

        public enum Direction
        {
            Vertical = 0,
            Horizontal = 1,
        }

        #endregion Enums

        #region Classes/Interfaces

        private class CustomLinearLayoutManager : LinearLayoutManager
        {
            #region Constructors/Finalizers

            public CustomLinearLayoutManager(Context context) 
                : base(context)
            {
                ScrollingEnabled = true;
            }

            public CustomLinearLayoutManager(Context context, int orientation, bool reverseLayout) 
                : base(context, orientation, reverseLayout)
            {
                ScrollingEnabled = true;
            }

            public CustomLinearLayoutManager(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) 
                : base(context, attrs, defStyleAttr, defStyleRes)
            {
                ScrollingEnabled = true;
            }

            #endregion Constructors/Finalizers

            #region Properties/Indexers

            public bool ScrollingEnabled
            {
                get;
                set;
            }

            #endregion Properties/Indexers

            #region Methods/Events

            public override bool CanScrollHorizontally()
            {
                return ScrollingEnabled & base.CanScrollHorizontally();
            }

            public override bool CanScrollVertically()
            {
                return ScrollingEnabled & base.CanScrollVertically();
            }

            #endregion Methods/Events
        }

        #endregion Classes/Interfaces

    }
}
