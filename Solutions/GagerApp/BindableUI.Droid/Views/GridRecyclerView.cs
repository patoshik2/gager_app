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
using AndroidX.RecyclerView.Widget;
using BindableUI.Droid.Utils;

namespace BindableUI.Droid.Views
{
    /// <summary>
    /// A "RecyclerView" that imitates a GridView from UWP
    /// </summary>
    [Register("bindableUI.droid.views.GridRecyclerView")]
    public class GridRecyclerView : ListRecyclerViewBase
    {
        #region Fields

        private int _desiredSpanPixelSize = LayoutParams.MatchParent;
        private GridLayoutManager _layoutManager;
        private Direction _orientation = Direction.Vertical;
        private int _savedMeasuredHeight;
        private int _savedMeasuredWidth;
        private bool _spanCountPriority = true;

        #endregion Fields

        #region Constructors

        public GridRecyclerView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
        }

        public GridRecyclerView(Context context)
            : base(context)
        {
        }

        public GridRecyclerView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }

        public GridRecyclerView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected GridRecyclerView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Mutually exclusive with <see cref="SpanCount"/>
        /// When this property is set, <see cref="SpanCount"/> is recalculated and vice-versa
        /// </summary>
        public int DesiredSpanPixelSize
        {
            get => _desiredSpanPixelSize;
            set
            {
                if (_desiredSpanPixelSize != value)
                {
                    _desiredSpanPixelSize = value;
                    if (_desiredSpanPixelSize < 0)
                    {
                        _desiredSpanPixelSize = LayoutParams.MatchParent;
                    }
                    _spanCountPriority = false;
                    OnSpanSizeChanged();
                }
            }
        }

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

        /// <summary>
        /// Mutually exclusive with <see cref="DesiredSpanPixelSize"/>
        /// When this property is set, <see cref="DesiredSpanPixelSize"/> is recalculated and vice-versa
        /// </summary>
        public int SpanCount
        {
            get => _layoutManager.SpanCount;
            set
            {
                if (
                    _layoutManager.SpanCount != value &&
                    //TODO: Throw an exception. Should not handle invalid value.
                    value > 0
                    )
                {
                    _layoutManager.SpanCount = value;
                    _spanCountPriority = true;
                    OnSpanCountChanged();
                }
            }
        }

        #endregion Properties

        #region Methods

        protected override RecyclerView.LayoutManager CreateLayoutManager(Context context, IAttributeSet attrs)
        {
            //Not measured yet, so set the span equal to 1
            _layoutManager = new GridLayoutManager(Context, 1, GridLayoutManager.Vertical, false)
            {
                RecycleChildrenOnDetach = true
            };
            return _layoutManager;
        }

        protected sealed override ItemTouchCallback.Direction GetAllowedDragDirection()
        {
            return ItemTouchCallback.Direction.Up | ItemTouchCallback.Direction.Down | ItemTouchCallback.Direction.Left | ItemTouchCallback.Direction.Right;
        }

        protected override void OnInitializationComplete(Context context, IAttributeSet attrs)
        {
            ReadXmlAttributes(context, attrs);

            _savedMeasuredHeight = MeasuredHeight;
            _savedMeasuredWidth = MeasuredWidth;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            if (
                (_savedMeasuredHeight != MeasuredHeight && _layoutManager.Orientation == GridLayoutManager.Horizontal) ||
                (_savedMeasuredWidth != MeasuredWidth && _layoutManager.Orientation == GridLayoutManager.Vertical)
                )
            {
                if (_spanCountPriority)
                {
                    _desiredSpanPixelSize = CalculateSpanPixelSize(SpanCount, _layoutManager.Orientation);
                }
                else
                {
                    _layoutManager.SpanCount = CalculateSpanCount(_desiredSpanPixelSize, _layoutManager.Orientation);
                }
            }
            _savedMeasuredHeight = MeasuredHeight;
            _savedMeasuredWidth = MeasuredWidth;
        }

        private int CalculateSpanCount(int desiredSpanPixelSize, int orientation)
        {
            if (desiredSpanPixelSize == LayoutParams.MatchParent)
            {
                return 1;
            }

            int displaySize = 0;
            switch (orientation)
            {
                case GridLayoutManager.Vertical:
                    displaySize = MeasuredWidth;
                    break;
                case GridLayoutManager.Horizontal:
                    displaySize = MeasuredHeight;
                    break;
                default:
                    break;
            }
            int spanCount = displaySize / desiredSpanPixelSize;
            return spanCount;
        }

        private int CalculateSpanPixelSize(int spanCount, int orientation)
        {
            if (SpanCount == 0)
            {
                //This shouldn't happen!
                return orientation == GridLayoutManager.Vertical ? MeasuredWidth : MeasuredHeight;
            }

            int displaySize = 0;
            switch (orientation)
            {
                case GridLayoutManager.Vertical:
                    displaySize = MeasuredWidth;
                    break;
                case GridLayoutManager.Horizontal:
                    displaySize = MeasuredHeight;
                    break;
                default:
                    break;
            }
            int desiredSpanPixelSize = displaySize / spanCount;
            return desiredSpanPixelSize;
        }

        private void OnScrollDirectionChanged()
        {
            int orientation = ScrollDirection == Direction.Vertical ? LinearLayoutManager.Vertical : LinearLayoutManager.Horizontal;
            _layoutManager.Orientation = orientation;
            //TODO: do we need to invoke additional methods?
        }

        private void OnSpanCountChanged()
        {
            _desiredSpanPixelSize = CalculateSpanPixelSize(SpanCount, _layoutManager.Orientation);
        }

        private void OnSpanSizeChanged()
        {
            _layoutManager.SpanCount = CalculateSpanCount(_desiredSpanPixelSize, _layoutManager.Orientation);
        }

        private void ReadXmlAttributes(Context context, IAttributeSet attrs)
        {
            if (IsInEditMode)
            {
                return;
            }

            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.GridRecyclerView);
            if (typedArray != null)
            {
                int scrollDirection = typedArray.GetInt(Resource.Styleable.GridRecyclerView_scrollDirection, (int)Direction.Vertical);
                ScrollDirection = (Direction)scrollDirection;
                DesiredSpanPixelSize = typedArray.GetDimensionPixelSize(Resource.Styleable.GridRecyclerView_spanSize, LayoutParams.MatchParent);
            }
            typedArray?.Recycle();
        }

        #endregion Methods

        #region Enums

        public enum Direction
        {
            Vertical = 0,
            Horizontal = 1,
        }

        #endregion Enums

    }
}
