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
using AndroidX.RecyclerView.Widget;

namespace BindableUI.Droid.Utils
{
    public class ItemTouchCallback : ItemTouchHelper.Callback
    {
        #region Fields

        private readonly IItemTouchCallbackManager _callbackManager;

        #endregion Fields

        #region Constructors/Finalizers

        public ItemTouchCallback(IItemTouchCallbackManager callbackHandler)
        {
            _callbackManager = callbackHandler ?? throw new ArgumentNullException(nameof(callbackHandler));
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public override bool IsLongPressDragEnabled => _callbackManager.CanDragByLongPress;

        #endregion Properties/Indexers

        #region Methods/Events

        public override void ClearView(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            base.ClearView(recyclerView, viewHolder);
            _callbackManager.OnItemDropped(recyclerView, viewHolder.AdapterPosition);
        }

        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            var allowedDirections = _callbackManager.GetAllowedDragDirections(recyclerView, viewHolder);
            int dragFlags = 0;
            if ((allowedDirections & Direction.Up) == Direction.Up)
            {
                dragFlags |= ItemTouchHelper.Up;
            }
            if ((allowedDirections & Direction.Down) == Direction.Down)
            {
                dragFlags |= ItemTouchHelper.Down;
            }
            if ((allowedDirections & Direction.Left) == Direction.Left)
            {
                dragFlags |= ItemTouchHelper.Left;
            }
            if ((allowedDirections & Direction.Right) == Direction.Right)
            {
                dragFlags |= ItemTouchHelper.Right;
            }
            System.Diagnostics.Debug.WriteLine($"{nameof(ItemTouchCallback)}.{nameof(GetMovementFlags)}: {dragFlags}");
            return MakeMovementFlags(dragFlags, 0);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            _callbackManager.OnItemDragMoved(recyclerView, viewHolder.AdapterPosition, target.AdapterPosition);
            return true;
        }

        public override void OnSelectedChanged(RecyclerView.ViewHolder viewHolder, int actionState)
        {
            System.Diagnostics.Debug.WriteLine($"{nameof(ItemTouchCallback)}.{nameof(OnSelectedChanged)}: {actionState}");
            if (actionState == ItemTouchHelper.ActionStateDrag)
            {
                _callbackManager.OnItemDragStarted();
            }
            base.OnSelectedChanged(viewHolder, actionState);
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            //Nothing yet
        }

        #endregion Methods/Events

        [Flags]
        public enum Direction
        {
            None = 0,
            Up = 1,
            Down = 2,
            Vertical = Up | Down,
            Left = 4,
            Right = 8,
            Horizontal = Left | Right,
            All = Vertical | Horizontal
        }
    }
}
