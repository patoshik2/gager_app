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
    public interface IItemTouchCallbackManager
    {
        #region Methods/Events

        bool CanDragByLongPress
        {
            get;
        }

        /// <summary>
        /// Dragged item is being moved across the other items
        /// </summary>
        /// <param name="recyclerView"></param>
        /// <param name="fromPosition"></param>
        /// <param name="toPosition"></param>
        void OnItemDragMoved(RecyclerView recyclerView, int fromPosition, int toPosition);

        /// <summary>
        /// Just to inform that the dragging has been started
        /// </summary>
        void OnItemDragStarted();

        /// <summary>
        /// Dragging has been finished. Item has been dropped.
        /// </summary>
        /// <param name="recyclerView"></param>
        /// <param name="dropPosition"></param>
        void OnItemDropped(RecyclerView recyclerView, int dropPosition);

        ItemTouchCallback.Direction GetAllowedDragDirections(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder);

        #endregion Methods/Events
    }
}
