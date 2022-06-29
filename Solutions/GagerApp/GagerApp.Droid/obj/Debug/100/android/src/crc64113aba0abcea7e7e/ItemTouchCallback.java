package crc64113aba0abcea7e7e;


public class ItemTouchCallback
	extends androidx.recyclerview.widget.ItemTouchHelper.Callback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isLongPressDragEnabled:()Z:GetIsLongPressDragEnabledHandler\n" +
			"n_clearView:(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V:GetClearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_getMovementFlags:(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)I:GetGetMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onMove:(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z:GetOnMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onSelectedChanged:(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V:GetOnSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler\n" +
			"n_onSwiped:(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V:GetOnSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler\n" +
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Utils.ItemTouchCallback, BindableUI.Droid", ItemTouchCallback.class, __md_methods);
	}


	public ItemTouchCallback ()
	{
		super ();
		if (getClass () == ItemTouchCallback.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Utils.ItemTouchCallback, BindableUI.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean isLongPressDragEnabled ()
	{
		return n_isLongPressDragEnabled ();
	}

	private native boolean n_isLongPressDragEnabled ();


	public void clearView (androidx.recyclerview.widget.RecyclerView p0, androidx.recyclerview.widget.RecyclerView.ViewHolder p1)
	{
		n_clearView (p0, p1);
	}

	private native void n_clearView (androidx.recyclerview.widget.RecyclerView p0, androidx.recyclerview.widget.RecyclerView.ViewHolder p1);


	public int getMovementFlags (androidx.recyclerview.widget.RecyclerView p0, androidx.recyclerview.widget.RecyclerView.ViewHolder p1)
	{
		return n_getMovementFlags (p0, p1);
	}

	private native int n_getMovementFlags (androidx.recyclerview.widget.RecyclerView p0, androidx.recyclerview.widget.RecyclerView.ViewHolder p1);


	public boolean onMove (androidx.recyclerview.widget.RecyclerView p0, androidx.recyclerview.widget.RecyclerView.ViewHolder p1, androidx.recyclerview.widget.RecyclerView.ViewHolder p2)
	{
		return n_onMove (p0, p1, p2);
	}

	private native boolean n_onMove (androidx.recyclerview.widget.RecyclerView p0, androidx.recyclerview.widget.RecyclerView.ViewHolder p1, androidx.recyclerview.widget.RecyclerView.ViewHolder p2);


	public void onSelectedChanged (androidx.recyclerview.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onSelectedChanged (p0, p1);
	}

	private native void n_onSelectedChanged (androidx.recyclerview.widget.RecyclerView.ViewHolder p0, int p1);


	public void onSwiped (androidx.recyclerview.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onSwiped (p0, p1);
	}

	private native void n_onSwiped (androidx.recyclerview.widget.RecyclerView.ViewHolder p0, int p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
