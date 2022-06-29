package crc64939f38f4a8d262b7;


public abstract class SingleSelectionAdapterCore_1
	extends crc64939f38f4a8d262b7.BindableRecyclerViewAdapterCore_1
	implements
		mono.android.IGCUserPeer,
		androidx.recyclerview.widget.RecyclerView.RecyclerListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onViewAttachedToWindow:(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V:GetOnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onViewDetachedFromWindow:(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V:GetOnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler\n" +
			"n_onViewRecycled:(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V:GetOnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IRecyclerListenerInvoker, Xamarin.AndroidX.RecyclerView\n" +
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Adapters.SingleSelectionAdapterCore`1, BindableUI.Droid", SingleSelectionAdapterCore_1.class, __md_methods);
	}


	public SingleSelectionAdapterCore_1 ()
	{
		super ();
		if (getClass () == SingleSelectionAdapterCore_1.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Adapters.SingleSelectionAdapterCore`1, BindableUI.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onViewAttachedToWindow (androidx.recyclerview.widget.RecyclerView.ViewHolder p0)
	{
		n_onViewAttachedToWindow (p0);
	}

	private native void n_onViewAttachedToWindow (androidx.recyclerview.widget.RecyclerView.ViewHolder p0);


	public void onViewDetachedFromWindow (androidx.recyclerview.widget.RecyclerView.ViewHolder p0)
	{
		n_onViewDetachedFromWindow (p0);
	}

	private native void n_onViewDetachedFromWindow (androidx.recyclerview.widget.RecyclerView.ViewHolder p0);


	public void onViewRecycled (androidx.recyclerview.widget.RecyclerView.ViewHolder p0)
	{
		n_onViewRecycled (p0);
	}

	private native void n_onViewRecycled (androidx.recyclerview.widget.RecyclerView.ViewHolder p0);

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
